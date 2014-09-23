using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysPPS.Entity;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity.StoredProcedure;
using AlwaysPPS.Entity.ViewModel;
using AlwaysPPS.Library.Constant;

namespace AlwaysPPS.Service
{
    public interface IProjectService
    {
        IList<VProject> GetToDoProjects(int UserId);
        IList<VProject> GetMyProject(int UserId);
        bool CloseProject(int ProjectId);
        List<SpSearchProject> SearchProjects(SearchParameter parameter);
        List<string> GetProjectCodeAll();
        List<string> GetClientNameAll();
        List<string> GetStatusAll();
        List<string> GetStateAll();
        TProject GetLastModel();
        List<string> GetProjectCodeAllByID(string procode);

        List<string> GetClienNameByType();

        List<TProject> GetProjectsByType();
        #region 1.0 新增操作 + void Add(TProject model)
        /// <summary>
        /// 新增操作
        /// </summary>
        /// <param name="model"></param>
        void Add(TProject model);
        #endregion

        #region 2.0 获得用户名 + List<string> GetClients(string name)
        /// <summary>
        /// 获得用户名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<string> GetClients(string name); 
        #endregion

        void Update(TProject tProject);

        TProject GetByID(int id);

        TProject GetProjectByAnPai(int pid);
    }

    public class ProjectService : IProjectService
    {
        private readonly IRepository<TProject> _projectRepository;
        private readonly IRepository<VProject> _vprojectRepository; 
        private readonly IRepository<TProjectTask> _taskRepository;
        private readonly IRepository<SpSearchProject> _SpSearchProject;
        private readonly IRepository<CtProjectType> _projectType;
        private readonly IRepository<TResourceTeam> _teamRepository;
        private readonly IRepository<TProjectWorkPlan> _workPlanRepository;
        private readonly IRepository<TResourceTeam> _resourceRepository; 

        public ProjectService(
            IRepository<TProject> projectRepository,
            IRepository<VProject> vprojectRepository,
            IRepository<TProjectTask> tastRepository,
            IRepository<SpSearchProject> SpSearchProject,
            IRepository<CtProjectType> projectType,
            IRepository<TResourceTeam> teamRepository,
            IRepository<TProjectWorkPlan> workPlanRepository,
            IRepository<TResourceTeam> resourceRepository)
        {
           this._vprojectRepository = vprojectRepository;
            this._projectRepository = projectRepository;
           this._taskRepository = tastRepository;
            this._SpSearchProject = SpSearchProject;
            this._projectType = projectType;
            this._teamRepository = teamRepository;
            this._workPlanRepository = workPlanRepository;
            this._resourceRepository = resourceRepository;
        }

        public IList<VProject> GetToDoProjects(int UserId)
        {
            var isApprove = _taskRepository.Query().Filter(x => x.Decision != "R").Get().Select(x => x.ProjectId).ToList();
            return _vprojectRepository.Query().Filter(x => x.AssignedToUid == UserId && x.Status == "A" && isApprove.Contains(x.ProjectId) && x.State != DataStatus.ProjectState.closed).OrderBy(x => x.OrderByDescending(y => y.RequestedDate)).Get().ToList();
        }

        public IList<VProject> GetMyProject(int UserId)
        {
            var proj = _taskRepository.Query().Filter(x => x.AssigneeUid == UserId || x.CreatedByUid == UserId).Get().Select(x => x.ProjectId).Distinct().ToList();
            var proj2 = _workPlanRepository.Query().Filter(x => x.ResourceUid == UserId).Get().Select(x => x.ProjectId).Distinct().ToList();
            return _vprojectRepository.Query().Filter(x => (proj.Contains(x.ProjectId) || proj2.Contains(x.ProjectId)) && x.State != DataStatus.ProjectState.closed).Get().OrderByDescending(x => x.RequestedDate).ToList();
        }

        public bool CloseProject(int ProjectId)
        {
            try
            {
                var exisiting = _projectRepository.Query().Filter(x => x.ProjectId == ProjectId).Get().FirstOrDefault();
                if (exisiting != null)
                {
                    if (exisiting.Status == "C")
                    {
                        throw new Exception("无需重复关闭");
                    }
                    exisiting.Status = "C";
                    _projectRepository.Update(exisiting);
                   
                    return true;
                }
                else
                {
                    throw new Exception("参数错误");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }


        #region 1.0 新增操作 + void Add(TProject model)
        public void Add(TProject model)
        {
            _projectRepository.Insert(model);
        }
        #endregion

        #region 2.0 根据用户输入 获得包含的用户名 + List<string> GetClients(string name)
        /// <summary>
        /// 根据用户输入 获得包含的用户名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<string> GetClients(string name)
        {
            return _projectRepository.Query().Filter(x => x.ClientName.Contains(name)).Get().Select(x => x.ClientName).ToList();
        } 
        #endregion


        public TProject GetLastModel()
        {
          return   _projectRepository.Query().Get().OrderByDescending(x => x.ProjectId).FirstOrDefault();
        }


        public void Update(TProject tProject)
        {

            _projectRepository.Update(tProject);
       

        }


        /// <summary>
        /// 根据Id 获取对应实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TProject GetByID(int id)
        {
            return _projectRepository.Query().Filter(x => x.ProjectId == id&&x.Status=="A").Get().FirstOrDefault();
        }


        //搜索项目
        public List<SpSearchProject> SearchProjects(SearchParameter parameter)
        {
            return _SpSearchProject.ExecuteStoredProcedure(SpSearchProject.NAME, SpSearchProject.Parameters(parameter)).ToList();
        }

        public List<string> GetProjectCodeAll()
        {
            return _projectRepository.Query().Get().Select(x => x.ProjectCode).Distinct().ToList();
        }
        public List<string> GetProjectCodeAllByID(string procode)
        {
            return _projectRepository.Query().Filter(x => x.ProjectCode.Contains(procode)).Get().Select(x => x.ProjectCode).Distinct().ToList();
        }

        public List<string> GetClientNameAll()
        {
            return _projectRepository.Query().Get().Select(x => x.ClientName).Distinct().ToList();
        }

        public List<string> GetStatusAll()
        {
            return _projectRepository.Query().Get().Select(x => x.Status).Distinct().ToList();
        }
        public List<string> GetStateAll()
        {
            return _projectRepository.Query().Get().Select(x => x.State).Distinct().ToList();
        }

        public TProject GetProjectByAnPai(int pid)
        {
            return _projectRepository.Query().Filter(u => u.ProjectId == pid && (u.State == DataStatus.ProjectState.pendingByTeamLeaderEnd || u.State == DataStatus.ProjectState.closed)).Get().FirstOrDefault();
        }

        public List<string>  GetClienNameByType()
        {
            return _projectRepository.Query().Filter(u => u.ProjectTypeId == 2).Get().Select(u => u.ClientName).Distinct().ToList();
        }

        public  List<TProject>  GetProjectsByType()
        {
            return _projectRepository.Query().Filter(u => u.ProjectTypeId == 2).Get().ToList();
        }
    }
}
