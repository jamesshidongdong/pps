using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity.StoredProcedure;

namespace AlwaysPPS.Service
{
    public interface ISpRPTTeamTimeSheetServer
    {
        List<SpRPTTeamTimeSheet> GetRPPTList(SpRPTParameter parameter);

    }

    public class PRPTTeamTimeSheetServer:ISpRPTTeamTimeSheetServer
    {
        private readonly Repository<SpRPTTeamTimeSheet> _repository;

        public PRPTTeamTimeSheetServer(Repository<SpRPTTeamTimeSheet> _repository)
        {
            this._repository = _repository;

        }
        public List<SpRPTTeamTimeSheet> GetRPPTList(SpRPTParameter parameter)
        {
          return  _repository.ExecuteStoredProcedure(SpRPTTeamTimeSheet.NAME,
                                               SpRPTTeamTimeSheet.Parameters(parameter)).ToList();
        }
    }
}
