using DataServices.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataServices
{
    public class RoleService
    {
        /// <summary>
        /// 角色信息（实际上这些应该存在数据库）
        /// </summary>
        public static List<RoleEntity> Roles = new List<RoleEntity>
        {
            new RoleEntity(){  RoleId="R01" ,RoleName="管理员" },
            new RoleEntity(){  RoleId="R02" ,RoleName="普通员工" }
        };
    }
}