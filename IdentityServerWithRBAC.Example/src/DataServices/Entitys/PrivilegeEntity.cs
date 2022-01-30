using System;
using System.Collections.Generic;
using System.Text;

namespace DataServices.Entitys
{
    public class PrivilegeEntity
    {

        public string PrivilegeId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public string RoleId { get; set; }



        public string PrivilegeName { get; set;}
        public string PrivilegeScope { get; set;}
    }
}
