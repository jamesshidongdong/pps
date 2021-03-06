﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Service
{
    public interface ITResourceTeamService
    {
        List<TResourceTeam> GetByUid(int uid);

        /// <summary>
        /// 根据 团队 并且角色为Traffic Leader 获取实体
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        TResourceTeam GetByTid(int tid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<TResourceTeam> GeTeamsByUid(int uid);


        TResourceTeam GetTeamLeader(int teamid, int managerid);

        /// <summary>
        /// 根据 teamid 获取较色为Traffice 实体
        /// </summary>
        /// <param name="teamid"></param>
        /// <returns></returns>
        TResourceTeam GetTraffice(int teamid);

        List<TResourceTeam> GeTeamMember(int teamid);

        /// <summary>
        /// 获得traffic下所有成员
        /// </summary>
        /// <param name="teamid"></param>
        /// <returns></returns>
        List<TResourceTeam> GetMembers(int teamid);


        List<TResourceTeam> GetTeamsList(int uid);

        List<TResourceTeam> GeTeams(int uid, int roleID);
        TResourceTeam GetTeamLeader(int uid);
        TResourceTeam GetTrafic(int uid);

        TResourceTeam GEtLeader(int resID);


        /// <summary>
        /// 根据所在组 角色为组长 获得具体实体对象
        /// </summary>
        /// <param name="subTeam"></param>
        /// <returns></returns>
        TResourceTeam GetLeader(int subTeam);

        /// <summary>
        /// 根据组长的id 和所在的组 获得成员
        /// </summary>
        /// <param name="manageuid"></param>
        /// <param name="subTeam"></param>
        /// <returns></returns>
        List<TResourceTeam> GeetMembers(int manageuid, int subTeam);

        //判断人员是否为trafficLeader or teamLeader
        bool IsCanEdit(int uid, int projId);

        /// <summary>
        /// 获取当前用户下所有的成员
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<int> GetCurrentUInts(int uid);


        List<int> GetSubTeamID(int uid);


        /// <summary>
        /// 获得团队下所有的员工
        /// </summary>
        /// <param name="subTeam"></param>
        /// <returns></returns>
        Dictionary<int, string> GetUserInts(int subTeam);


        Dictionary<int, string> GetSubTeamresource(int uid);

    }

    public class TResourceTeamService : ITResourceTeamService
    {
        private readonly IRepository<TResourceTeam> _tResourceTeam;
        private readonly IRepository<TProjectTask> _TProjectTask;
        private readonly IRepository<TProject> _project;
        private readonly IRepository<OaEmployee> _OaEmployee;


        public TResourceTeamService(
            IRepository<TResourceTeam> _TResourceTeam
            , IRepository<TProjectTask> tProjectTask
            , IRepository<TProject> project
            , IRepository<OaEmployee> _OaEmployee)
        {
            this._tResourceTeam = _TResourceTeam;
            this._TProjectTask = tProjectTask;
            this._project = project;
            this._OaEmployee = _OaEmployee;
        }

        public List<TResourceTeam> GetByUid(int uid)
        {
          return  _tResourceTeam.Query().Filter(x => x.ResourceUid == uid).Get().ToList();
        }


        public TResourceTeam GetByTid(int tid)
        {
           return _tResourceTeam.Query().Filter(x => x.TeamId == tid && x.RoleId==1).Get().FirstOrDefault();
           
        }

    


        public List<TResourceTeam> GeTeamsByUid(int uid)
        {
            return _tResourceTeam.Query().Filter(x => x.ResourceUid == uid && x.RoleId == 1).Get().ToList();
        }


        /// <summary>
        /// 根据所在组 角色为组长 获得具体实体对象
        /// </summary>
        /// <param name="subTeam"></param>
        /// <returns></returns>
        public TResourceTeam GetLeader(int subTeam)
        {
            return _tResourceTeam.Query().Filter(u => u.SubTeamId == subTeam && u.RoleId == 2).Get().FirstOrDefault();
        }


        public TResourceTeam GetTeamLeader(int teamid,int managerid)
        {
           
            return
                _tResourceTeam.Query()
                    .Filter(x => x.TeamId == teamid && x.ManagerUid == managerid)
                    .Get()
                    .FirstOrDefault();
        }

        /// <summary>
        /// 根据 teamid 获取较色为Traffice 实体
        /// </summary>
        /// <param name="teamid"></param>
        /// <returns></returns>
        public TResourceTeam GetTraffice(int teamid)
        {
            //add Isd eleted 条件 
           
            return _tResourceTeam.Query().Filter(x => x.TeamId == teamid && x.RoleId == 1 && x.Isdeleted==false).Get().FirstOrDefault();
        }

        /// <summary>
        ///获得所有组成员
        /// </summary>
        /// <param name="teamid"></param>
        /// <returns></returns>
        public List<TResourceTeam> GeTeamMember(int teamid)
        {
           
          return   _tResourceTeam.Query().Filter(x => x.TeamId == teamid && x.RoleId == 3).Get().ToList();
        }

        /// <summary>
        /// 获取 trffic 所能看到的所有成员
        /// </summary>
        /// <param name="teamid"></param>
        /// <returns></returns>
        public List<TResourceTeam> GetMembers(int teamid)
        {
           return _tResourceTeam.Query().Filter(x => x.TeamId == teamid && x.RoleId != 1 && x.Isdeleted==false).Get().ToList();
        }


        /// <summary>
        /// 获得组长下面所有的成员
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<TResourceTeam> GetTeamsList(int uid)
        {
          return   _tResourceTeam.Query().Filter(u => u.ManagerUid == uid && u.Isdeleted==false).Get().ToList();
        }


        public List<TResourceTeam> GeTeams(int uid, int roleID)
        {
            return _tResourceTeam.Query().Filter(u => u.ResourceUid == uid && u.RoleId == roleID).Get().ToList();
        }

        #region 获取当前用户下 所有的成员 +  List<int> GetCurrentUInts(int uid)

        /// <summary>
        /// 获取当前用户下 所有的成员
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<int> GetCurrentUInts(int uid)
        {

            List<int> res = new List<int>();
            //获取trffice 或者teamleader 实体  add  员工在组内是否被删除
            var model = _tResourceTeam.Query().Filter(u => u.ResourceUid == uid && u.Isdeleted==false).Get().FirstOrDefault();
            if (model != null)
            {
                //角色为teamLeader 就获取下面所有的成员 和本人
                if (model.RoleId == 2)
                {
                    res.Add(model.ResourceUid);
                    var resTeammeber =
                        _tResourceTeam.Query().Filter(u => u.ManagerUid == model.ResourceId && u.Isdeleted==false).Get().ToList();
                    if (resTeammeber.Any())
                    {
                        foreach (var item in resTeammeber)
                        {
                            res.Add(item.ResourceUid);
                        }
                    }
                }
                if (model.RoleId == 1)
                {
                    var resTeamLeads =
                        _tResourceTeam.Query().Filter(u => u.ManagerUid == model.ResourceId && u.Isdeleted==false).Get().ToList();
                    if (resTeamLeads.Any())
                    {
                        foreach (var itemLeaders in resTeamLeads)
                        {
                            if (itemLeaders != null)
                            {
                                res.Add(itemLeaders.ResourceUid);
                                var resmembers = _tResourceTeam.Query()
                                    .Filter(u => u.ManagerUid == itemLeaders.ResourceId && u.Isdeleted==false)
                                    .Get()
                                    .ToList();
                                if (resmembers.Any())
                                {
                                    foreach (var items in resmembers)
                                    {
                                        res.Add(items.ResourceUid);
                                    }
                                }
                            }
                        }
                    }
                }

            }
            return res;
        }

        #endregion


        public Dictionary<int,string>  GetSubTeamresource(int uid)
        {
            List<int> userInts = GetCurrentUInts(uid);
            Dictionary<int,string> result=new Dictionary<int, string>();
            if(userInts.Any())
            {
                foreach (var userInt in userInts)
                {
                    var res = _OaEmployee.Query().Filter(u => u.UserId == userInt).Get().FirstOrDefault();
                    if(res==null)
                    {
                        continue;
                        
                    }
                    else
                    {
                        result.Add(userInt, res.EmployeeName);
                    }
                }
               
            }
            return result;
        }


        /// <summary>
        /// 根据用户ID 并且是组长 获得对象
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public TResourceTeam GetTeamLeader(int uid)
        {
         return    _tResourceTeam.Query().Filter(u => u.ResourceUid == uid && u.RoleId == 2).Get().FirstOrDefault();
        }


        public TResourceTeam GEtLeader(int resID)
        {
            return _tResourceTeam.Query().Filter(u => u.ResourceId == resID).Get().FirstOrDefault();
        }

        public TResourceTeam GetTrafic(int uid)
        {
            return _tResourceTeam.Query().Filter(u => u.ResourceUid == uid && u.RoleId == 1).Get().FirstOrDefault();
        }

        /// <summary>
        /// 根据组长的id 和所在的组 获得成员
        /// </summary>
        /// <param name="manageuid"></param>
        /// <param name="subTeam"></param>
        /// <returns></returns>
        public List<TResourceTeam> GeetMembers(int manageuid, int subTeam)
        {
            return
                _tResourceTeam.Query().Filter(u => u.ManagerUid == manageuid && u.SubTeamId == subTeam && u.RoleId==3).Get().ToList();
        }

        public bool IsCanEdit(int uid, int projId)
        {
            bool isTraffic = _tResourceTeam.Query().Filter(x=>x.ResourceUid==uid && x.RoleId==1).Get().ToList().Any();
            if (isTraffic)
            {
                return true;//待定
            }
            //表名是PM 或者是Buheader
            bool isPMorBu = _tResourceTeam.Query().Filter(x => x.ResourceUid == uid && (x.RoleId == 1||x.RoleId == 2||x.RoleId == 3)).Get().ToList().Any();
            if (isPMorBu==false)
            {
                return true;//待定
            }
            var assignToUid=_project.Query().Filter(x=>x.ProjectId==projId).Get().Select(x=>x.AssignedToUid).FirstOrDefault();
            bool isCurrentProjTeamLeader = uid == assignToUid;
            if (isCurrentProjTeamLeader)
            {
                return true;//当前项目的组长
            }
            
            return false;//TeamMember不能编辑
        }


       public  List<int> GetSubTeamID(int uid)
       {
           List<int> subRes = new List<int>();
           //添加是否被删除状态
           var res = _tResourceTeam.Query().Filter(u => u.ResourceUid == uid && u.RoleId==1 &&u.Isdeleted==false).Get().FirstOrDefault();
           if(res!=null)
           {
              var sub=  _tResourceTeam.Query().Filter(u => u.ManagerUid.Value == res.ResourceId && u.Isdeleted==false).Get();
             
               foreach (var subRe in sub)
               {
                   if(subRe!=null)
                   {
                       subRes.Add(subRe.SubTeamId.Value);
                   }
               }

           }
           return subRes;
       }


       public Dictionary<int, string> GetUserInts(int subTeam)
       {

           Dictionary<int,string> employee=new Dictionary<int, string>();
           var res = _tResourceTeam.Query().Filter(u => u.SubTeamId == subTeam && u.Isdeleted==false).Get().ToList();
           List<int> result = new List<int>();
           if (res.Any())
           {
               foreach (var model in res)
               {
                   if (model != null)
                   {
                       result.Add(model.ResourceUid);
                   }
               }
           }
           foreach (var i in result)
           {
               var resultEmp = _OaEmployee.Query().Filter(u => u.UserId == i).Get().FirstOrDefault();
               if(result==null)
               {
                   continue;
               }
               else
               {
                   employee.Add(i, resultEmp.EmployeeName);
               }
           }
           return employee;
       }


    }
}
