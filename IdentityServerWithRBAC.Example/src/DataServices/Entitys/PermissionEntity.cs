using System;
using System.Collections.Generic;
using System.Text;

namespace DataServices.Entitys
{
    public class PermissionEntity
    {
        /// <summary>
        /// 权限id
        /// </summary>

        public string PermissionId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Api的唯一识别明（本demo用程序集名称）
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        /// 已授权Action
        /// </summary>
        public string[] AuthorisedActions { get; set; }

        /// <summary>
        /// 已授权controller
        /// </summary>
        public string[] AuthorisedControllers { get; set; }
    }
}