using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Service
{
    public interface ICtProjectMileStoneTemplateService
    {
        List<CtProjectMileStoneTemplate> GetByPtype(int ptype);
    }

    public class CtProjectMileStoneTemplateService : ICtProjectMileStoneTemplateService
    {

        private readonly IRepository<CtProjectMileStoneTemplate> _repository;

        public CtProjectMileStoneTemplateService(IRepository<CtProjectMileStoneTemplate> _ctrepository)
        {
            _repository = _ctrepository;
        }

       public  List<CtProjectMileStoneTemplate> GetByPtype(int ptype)
       {
           return _repository.Query().Filter(u => u.ProjectType == ptype).Get().ToList();
       }
    }
}
