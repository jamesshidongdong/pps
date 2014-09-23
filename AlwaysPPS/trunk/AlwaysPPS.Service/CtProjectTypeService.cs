﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Service
{
    public interface ICtProjectTypeService
    {
        #region 1.0 获取所有项目类别 +  List<CtProjectType> GetTypes()
        /// <summary>
        /// 获取所有项目类别
        /// </summary>
        /// <returns></returns>
        List<CtProjectType> GetTypes(); 
        #endregion

        #region 2.0 根据ID 获取项目类别 +  CtProjectType GetByID(int id)
        /// <summary>
        /// 根据ID 获取项目类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CtProjectType GetByID(int id); 
        #endregion


        CtProjectType GetByTeamId(int id);

        CtProjectType GetByDept(int dept);
    }

    public class CtProjectTypeService : ICtProjectTypeService
    {
        private IRepository<CtProjectType> _CtProjectType;
        public CtProjectTypeService(IRepository<CtProjectType> _CtProjectType)
        {
            this._CtProjectType = _CtProjectType;
        }
        #region 1.0 获取所有项目类别 + List<CtProjectType> GetTypes()
        /// <summary>
        /// 获取所有项目类别
        /// </summary>
        /// <returns></returns>
        public List<CtProjectType> GetTypes()
        {
            return _CtProjectType.Query().Filter(u=>u.Status=="A").Get().Distinct().ToList();
        } 
        #endregion

        #region 2.0 根据Id 获得项目类别 + CtProjectType GetByID(int id)
        /// <summary>
        /// 根据Id 获得项目类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CtProjectType GetByID(int id)
        {
            return _CtProjectType.Query().Filter(u => u.ProjectTypeId == id).Get().FirstOrDefault();
        } 
        #endregion


        public CtProjectType GetByTeamId(int id)
        {
           return  _CtProjectType.Query().Filter(x => x.TeamId == id).Get().FirstOrDefault();
        }

        public CtProjectType GetByDept(int dept)
        {
            return _CtProjectType.Query().Filter(x => x.DepartmentId == dept).Get().FirstOrDefault();
        }
    }
}
