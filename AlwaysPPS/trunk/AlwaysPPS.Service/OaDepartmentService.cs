﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Service
{
    public interface IOaDepartment
    {
        #region 1.0 根据部门Id 获取实体 + OaDepartment GetByDepartmentID(int departmentid)
        /// <summary>
        /// 根据部门Id 获取实体
        /// </summary>
        /// <param name="departmentid"></param>
        /// <returns></returns>
        OaDepartment GetByDepartmentID(int departmentid);

        #endregion


        #region  2.0 获取所有部门 + List<OaDepartment> GetList()
        /// <summary>
        /// 获取所有部门
        /// </summary>
        /// <returns></returns>
        List<OaDepartment> GetList(); 
        #endregion

    }


    public class OaDepartmentService : IOaDepartment
    {
        private readonly IRepository<OaDepartment> _OaDepartment;

        public OaDepartmentService(IRepository<OaDepartment> _OaDepartment)
        {
            this._OaDepartment = _OaDepartment;
        }

        public OaDepartment GetByDepartmentID(int departmentid)
        {
           return  _OaDepartment.Query().Filter(x => x.DepartmentId == departmentid).Get().FirstOrDefault();
        }

        public List<OaDepartment> GetList()
        {
            return _OaDepartment.Query().Get().ToList();
        }

        
    }
}
