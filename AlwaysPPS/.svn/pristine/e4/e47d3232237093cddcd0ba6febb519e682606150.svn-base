using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity;
using AlwaysPPS.Library.Constant;

namespace AlwaysPPS.Service
{
    public interface ITProjectTaskService
    {
        void Add(TProjectTask model);

        TProjectTask GetTask(int proID, int uid);

        void Update(TProjectTask model);

        List<TProjectTask> GetMyTasks(int uid);

        /// <summary>
        /// 根据项目ID 
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        TProjectTask GeTaskByProID(int projectID);

        /// <summary>
        /// 根据 项目Id 获取组长
        /// </summary>
        /// <param name="proID"></param>
        /// <returns></returns>
        TProjectTask GeTask(int proID);

        /// <summary>
        /// 获取trffice已经分配完的项目
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        TProjectTask GTaskHavedTeamLead(int projectID);

        /// <summary>
        /// 获取trffice 已经审批完的数组
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        TProjectTask GTasked(int projectID);


        TProjectTask GetAssID(int projectID);

        TProjectTask GetTraffice(int projectid);

        TProjectTask GetBuHeader(int projectid);

        //TeamLeader分配人员时，update 自己的待分配数据为完成分配：Completed
        bool UpdateCompletedByTeamLeader(int pId, int uId);
    }

    public class TProjectTaskService : ITProjectTaskService
    {
        private readonly IRepository<TProjectTask> _TProjectTask;


        public TProjectTask GetTraffice(int projectid)
        {
            return
                _TProjectTask.Query().Filter(
                    u => u.ProjectId == projectid && u.TaskTypeCode == DataStatus.ProjectState.PTA && u.Status == DataStatus.ProjectState.C).Get().FirstOrDefault
                    ();
        }

        public TProjectTask GetBuHeader(int projectid)
        {
            return
                _TProjectTask.Query().Filter(
                    u => u.ProjectId == projectid && u.TaskTypeCode == DataStatus.ProjectState.BU).Get().FirstOrDefault
                    ();
        }

        public TProjectTaskService(IRepository<TProjectTask> _TProjectTask)
        {
            this._TProjectTask = _TProjectTask;
        }

        public void Add(TProjectTask model)
        {
            _TProjectTask.Insert(model);
        }

        public TProjectTask GetTask(int proID, int uid)
        {
          return  _TProjectTask.Query().Filter(x => x.ProjectId == proID && x.AssigneeUid==uid && x.Status=="P").Get().FirstOrDefault();
        }


        public TProjectTask GeTask(int proID)
        {
         return    _TProjectTask.Query()
                .Filter(x => x.ProjectId == proID && x.TaskTypeCode == "PendingResourceAllocation")
                .Get()
                .FirstOrDefault();
        }
        
        public void Update(TProjectTask model)
        {
            _TProjectTask.Update(model);
        }

        /// <summary>
        /// 获取当前人员所有的项目
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<TProjectTask> GetMyTasks(int uid)
        {
            List<TProjectTask> resList=new List<TProjectTask>();
          var list = _TProjectTask.Query().Filter(u => u.AssigneeUid == uid).Get().ToList();
            foreach (var projectTask in list)
            {
                var model =
                    _TProjectTask.Query()
                        .Filter(
                            x =>
                                x.ProjectId == projectTask.ProjectId && x.TaskTypeCode == "PendingResourceAllocation" &&
                                x.Status == "C" && x.Decision == "A")
                        .Get()
                        .FirstOrDefault();
                if (model != null)
                {

                    resList.Add(model);
                }
            }
            return resList.Distinct().ToList();
        }




        public TProjectTask GeTaskByProID(int projectID)
        {
            return
                _TProjectTask.Query()
                    .Filter(
                        u =>
                            u.ProjectId == projectID && u.TaskTypeCode == "PendingResourceAllocation" && u.Status == "C" &&
                            u.Decision == "A")
                    .Get()
                    .FirstOrDefault();
        }

        public TProjectTask GTaskHavedTeamLead(int projectID)
        {
            return
               _TProjectTask.Query()
                   .Filter(
                       u =>
                           u.ProjectId == projectID && u.TaskTypeCode == "PendingResourceAllocation" && (u.Status == "P" || u.Status=="C") &&
                           u.Decision == "A")
                   .Get()
                   .FirstOrDefault();
        }


        public TProjectTask GTasked(int projectID)
        {
            return
               _TProjectTask.Query()
                   .Filter(
                       u =>
                           u.ProjectId == projectID && u.TaskTypeCode == "PendingTeamLeadAssignment" && u.Status == "C" &&
                           u.Decision == "A")
                   .Get()
                   .FirstOrDefault();
        }

        
        public TProjectTask GetAssID(int projectID)
        {
            return
            _TProjectTask.Query()
                .Filter(
                    u =>
                        u.ProjectId == projectID && u.TaskTypeCode == "PendingTeamLeadAssignment" && u.Status == "P" &&
                        u.Decision == "A")
                .Get()
                .FirstOrDefault();
        }

        //TeamLeader分配人员时，update 自己的待分配数据为完成分配：Completed
        public bool UpdateCompletedByTeamLeader(int pId,int uId)
        {
            var model = _TProjectTask.Query().Filter(x => x.ProjectId == pId && x.AssigneeUid == uId).Get().FirstOrDefault();
            if (model != null)
            {
                model.Status = "C";
                _TProjectTask.Update(model);
                return true;
            }
            return false;
        }
    }
}
