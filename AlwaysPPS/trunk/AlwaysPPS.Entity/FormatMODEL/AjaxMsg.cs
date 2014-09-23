using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysPPS.Entity.FormatMODEL
{
    /// <summary>
    /// 返回给Ajax请求的 数据格式 模型
    /// </summary>
    public class AjaxMsg
    {
        public AjaxMsgStatu Statu { get; set; }
        public string Msg { get; set; }
        public string BackUrl { get; set; }
        public object Data { get; set; }
    }

    /// <summary>
    /// Ajax消息状态的 类型
    /// </summary>
    public enum AjaxMsgStatu
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        Ok = 1,
        /// <summary>
        /// 操作失败
        /// </summary>
        NoOk = 2,
        /// <summary>
        /// 尚未登陆
        /// </summary>
        NoLogin = 3,
        /// <summary>
        /// 没有访问权限
        /// </summary>
        NoPermission = 4,
        /// <summary>
        /// 异常
        /// </summary>
        Error = 5
    }
}
