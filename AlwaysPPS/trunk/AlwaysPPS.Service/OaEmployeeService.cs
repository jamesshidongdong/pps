using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Service
{
    public interface IOaEmployeeService
    {
        #region 1.0 根据用户Id 获取用户对象 +  OaEmployee GetByUid(int id)
        /// <summary>
        /// 根据用户Id 获取用户对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OaEmployee GetByUid(int id); 
        #endregion
    }

    public class OaEmployeeService : IOaEmployeeService
    {

        private readonly IRepository<OaEmployee> _OaEmployee;
        public OaEmployeeService(IRepository<OaEmployee> _OaEmployee)
        {
            this._OaEmployee = _OaEmployee;
        }

        #region 1.0 根据用户Id 获取用户对象 + OaEmployee GetByUid(int id)
        /// <summary> 
        /// 根据用户Id 获取用户对象  未删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OaEmployee GetByUid(int id)
        {
            return _OaEmployee.Query().Filter(x => x.UserId == id).Get().FirstOrDefault();
        }
        #endregion
    }
}