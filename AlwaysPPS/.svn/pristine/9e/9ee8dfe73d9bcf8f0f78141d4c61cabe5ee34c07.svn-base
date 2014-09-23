using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Service
{
    public interface ITProjectMilestoneService
    {
        void Add(TProjectMilestone model);

        List<TProjectMilestone> GetListByProjectID(int proid);
        void Update(TProjectMilestone model);
        TProjectMilestone GetByid(int id);

        TProjectMilestone GetMilestone(TProjectMilestone model);
    }

    public class TProjectMilestoneService : ITProjectMilestoneService
    {
        private readonly IRepository<TProjectMilestone> _TProjectMilestone;

        public TProjectMilestoneService(IRepository<TProjectMilestone> tProjectMilestone)
        {
            this._TProjectMilestone = tProjectMilestone;
        }

        public void Add(TProjectMilestone model)
        {
            model.Deleted = false;

            _TProjectMilestone.Insert(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        public List<TProjectMilestone> GetListByProjectID(int proid)
        {
          return   _TProjectMilestone.Query().Filter(x => x.ProjectId == proid && x.Deleted==false).Get().OrderBy(x=>x.ActualEndDate).ToList();
        }
        
        public void Update(TProjectMilestone model)
        {
            var newmodel = _TProjectMilestone.Query().Filter(u => u.ProjectMilestoneId == model.ProjectMilestoneId).Get().FirstOrDefault();
            if (newmodel != null)
            {
                newmodel.MilestoneName = model.MilestoneName;
                newmodel.ProjectId = model.ProjectId;
                newmodel.ActualEndDate = model.ActualEndDate;
                _TProjectMilestone.Update(newmodel);
            }
        }

        public TProjectMilestone GetByid(int id)
        {
            return _TProjectMilestone.Query().Filter(u => u.ProjectMilestoneId == id).Get().FirstOrDefault();
        }

        public TProjectMilestone GetMilestone(TProjectMilestone model)
        {
            return
                _TProjectMilestone.Query()
                    .Filter(u => u.MilestoneName == model.MilestoneName && u.ProjectId==model.ProjectId)
                    .Get()
                    .FirstOrDefault();
        }
    }

}
