using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity.StoredProcedure;

namespace AlwaysPPS.Service
{
    public  interface ISpRPTGetTimeSheetByTeamServer
    {
        List<SpRPTGetTimeSheetByTeam> GetList(GetTimeSheetParameter parameter);
    }

    public class SpRPTGetTimeSheetByTeamServer : ISpRPTGetTimeSheetByTeamServer
    {
        private readonly Repository<SpRPTGetTimeSheetByTeam> _rptGetTimeSheet;


        public SpRPTGetTimeSheetByTeamServer(Repository<SpRPTGetTimeSheetByTeam> _rptGetTimeSheet)
        {
            this._rptGetTimeSheet = _rptGetTimeSheet;
        }

        public List<SpRPTGetTimeSheetByTeam> GetList(GetTimeSheetParameter _byTeam)
        {
          return  _rptGetTimeSheet.ExecuteStoredProcedure(SpRPTGetTimeSheetByTeam.NAME,
                                                    SpRPTGetTimeSheetByTeam.Parameters(_byTeam)).ToList();
        }
    }
}
