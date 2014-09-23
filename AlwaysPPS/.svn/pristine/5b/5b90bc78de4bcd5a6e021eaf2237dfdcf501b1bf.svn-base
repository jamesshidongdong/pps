using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity.StoredProcedure;

namespace AlwaysPPS.Service
{
  public  interface ISpRPTByTeamTimeSheetServer
  {
      List<SpRPTByTeamTimeSheet> GetList(SpRPTByTeamParameter parameter);
  }

  public class PRPTByTeamTimeSheetServer : ISpRPTByTeamTimeSheetServer
    {

        private readonly Repository<SpRPTByTeamTimeSheet> _repository;

        public PRPTByTeamTimeSheetServer(Repository<SpRPTByTeamTimeSheet> _repository)
        {
            this._repository = _repository;

        }

        public List<SpRPTByTeamTimeSheet> GetList(SpRPTByTeamParameter parameter)
        {
            return
                _repository.ExecuteStoredProcedure(SpRPTByTeamTimeSheet.NAME, SpRPTByTeamTimeSheet.Parameters(parameter))
                    .ToList();
        }
    }
}
