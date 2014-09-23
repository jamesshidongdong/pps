using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Service
{
    public interface ICtTeamService
    {
       CtTeam GeTeams(int id);
       List<CtTeam> GetList(int parentID);

       CtTeam GetListByTeamID(int teamid);
    }

    public class CtTeamService : ICtTeamService
    {
        private IRepository<CtTeam> _CtTeam;
        public CtTeamService(IRepository<CtTeam> ctTeam)
        {
            this._CtTeam = ctTeam;
        }

        public CtTeam GeTeams(int id)
        {
           return  _CtTeam.Query().Filter(x=>x.TeamId==id).Get().FirstOrDefault();
        }

        public List<CtTeam> GetList(int parentID)
        {

            //添加Isdeleted 属性 表示该团队已经被删除
            return _CtTeam.Query().Filter(u => u.ParentId == parentID && u.Isdeleted == false).Get().ToList();
        }

        public  CtTeam GetListByTeamID(int teamid)
        {
          return   _CtTeam.Query().Filter(u => u.TeamId == teamid && u.Isdeleted==false).Get().FirstOrDefault();
        }
    }
}
