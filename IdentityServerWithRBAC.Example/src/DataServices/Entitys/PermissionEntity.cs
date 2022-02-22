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
        /// 已授权信息，这里简单写写 key=controller,value=
        /// </summary>
        public Dictionary<string, List<string>> Authorised { get; set; }
    }
}