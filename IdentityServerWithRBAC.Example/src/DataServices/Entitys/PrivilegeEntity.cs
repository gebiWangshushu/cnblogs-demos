using System;
using System.Collections.Generic;
using System.Text;

namespace DataServices.Entitys
{
    public class PrivilegeEntity
    {

        /// <summary>
        /// 权限id
        /// </summary>

        public string PrivilegeId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ControllerPattern { get; set; } = "*";

        /// <summary>
        /// 
        /// </summary>
        public string ActionPattern { get; set;} = "*";
    }
}
