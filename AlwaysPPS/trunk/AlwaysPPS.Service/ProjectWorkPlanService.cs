﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysFramework.DAL.Providers.EntityFramework;
using AlwaysPPS.Entity;
using AlwaysPPS.Entity.FormatMODEL;
using AlwaysPPS.Entity.StoredProcedure;
using AlwaysPPS.Library.Constant;

namespace AlwaysPPS.Service
{
    using System.Data;
    using System.Data.SqlClient;

    public interface IProjectWorkPlanService
    {
        TProjectWorkPlan GetWorkPlan(int id);
        bool AddWorkPlan(TProjectWorkPlan entity);
        bool UpdateWorkPlan(TProjectWorkPlan entity);
        List<VProjectWorkPlan> GetWorkPlanByProjectId(int projectId);
        bool SetDeleteWorkPlan(int Id);
        List<VTeamMember> GeTeamMembers (int TeamLeaderId);
        List<VProjectWorkPlan> GetWorkPlansByUsers(int userID);

        bool IsHumanExistWorkPlan(int projectId, int uid,int workPlanId);
        List<SpGetPlanTime> GetPlanTimes(PlanTimeParameter parameter);

        TProjectWorkPlan GetTime(int pid, int uid);
    }

    public class ProjectWorkPlanService : IProjectWorkPlanService
    {
        private readonly Repository<TProjectWorkPlan> _workPlanRepository;
        private readonly Repository<VProjectWorkPlan> _vworkPlanRepository;
        private readonly Repository<VTeamMember> _vteamMember;
        private readonly Repository<SpGetPlanTime> _SpGetPlanTime;
        public ProjectWorkPlanService(
            Repository<TProjectWorkPlan> workPlanRepository
            , Repository<VProjectWorkPlan> vworkPlanRepository
            , Repository<VTeamMember> vteamMember
            , Repository<SpGetPlanTime> SpGetPlanTime)
        {
            this._workPlanRepository = workPlanRepository;
            this._vworkPlanRepository = vworkPlanRepository;
            this._vteamMember = vteamMember;
            this._SpGetPlanTime = SpGetPlanTime;
        }

        public TProjectWorkPlan GetWorkPlan(int id)
        {
            return _workPlanRepository.Query().Filter(x => x.ProjectWorkPlanId == id).Get().FirstOrDefault();
        }

        public bool AddWorkPlan(TProjectWorkPlan entity)
        {
            entity.ActualEffort = Convert.ToDecimal(0.00);
             _workPlanRepository.Insert(entity);
            return true;
        }

        public bool UpdateWorkPlan(TProjectWorkPlan entity)
        {
            _workPlanRepository.Update(entity);
            return true;
        }

        public List<VProjectWorkPlan> GetWorkPlanByProjectId(int projectId)
        {
            return _vworkPlanRepository.Query().Filter(x => x.ProjectId == projectId && x.Deleted !=true).Get().OrderByDescending(x=>x.ProjectWorkPlanId).ToList();
        }

        public List<VProjectWorkPlan> GetWorkPlansByUsers(int userID)
        {
            return _vworkPlanRepository.Query().Filter(x => x.ResourceUid == userID).Get().ToList();
        }
        public bool SetDeleteWorkPlan(int Id)
        {
            var model = _workPlanRepository.Query().Filter(x => x.ProjectWorkPlanId == Id).Get().FirstOrDefault();
            if (model != null)
            {
                model.Deleted = true;
                _workPlanRepository.Update(model);
                return true;
            }
            else
            {
                throw new Exception("参数错误");
            }
        }

        public List<VTeamMember> GeTeamMembers(int TeamLeaderId)
        {
            var resourceId =
                _vteamMember.Query().Filter(x => x.ResourceUid == TeamLeaderId && x.RoleId == SystemRoles.TEL).Get().Select(x => x.ResourceId).FirstOrDefault();
            if (resourceId >0)
            {
                var member = _vteamMember.Query().Filter(x => x.ManagerUid == resourceId || x.ResourceId==resourceId).Get().ToList().Where(u=>u.Isdeleted==false).ToList();
                return member;
            }
            return null;
        }

        public bool IsHumanExistWorkPlan(int projectId, int uid,int workPlanId)
        {
            if (workPlanId > 0) //更新时（除本身之外不能有重复）
            {
                var model =
                    _workPlanRepository.Query()
                        .Filter(
                            x =>
                                x.ProjectId == projectId && x.ResourceUid == uid && x.Deleted != true &&
                                x.ProjectWorkPlanId != workPlanId)
                        .Get()
                        .ToList();
                if (model != null)
                {
                    return model.Count > 0;
                }
                else
                {
                    return false;
                }
            }
            else//新增时
            {
                var model =
                    _workPlanRepository.Query()
                        .Filter(x => x.ProjectId == projectId && x.ResourceUid == uid && x.Deleted != true)
                        .Get()
                        .ToList();
                if (model != null)
                {
                    return model.Count > 0;
                }
                else
                {
                    return false;
                }
            }
        }

      public  List<SpGetPlanTime>  GetPlanTimes(PlanTimeParameter parameter)
      {
          return _SpGetPlanTime.ExecuteStoredProcedure(SpGetPlanTime.NAME, SpGetPlanTime.Parameters(parameter)).ToList();
      }


        public TProjectWorkPlan GetTime(int pid,int uid)
        {
          return    _workPlanRepository.Query().Filter(u => u.ProjectId == pid && u.ResourceUid == uid).Get().FirstOrDefault();
        }


    }
}
