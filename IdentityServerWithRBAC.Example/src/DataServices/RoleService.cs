using DataServices.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataServices
{
    public class RoleService
    {
        public static List<RoleEntity> Roles = new List<RoleEntity>
        {
            new RoleEntity(){  RoleId="R01" ,RoleName="管理员" },
            new RoleEntity(){  RoleId="R02" ,RoleName="普通员工" }
        };

        //public static RoleEntity GetUserPermissionBySubid(string roleId)
        //{
        //    return _roles.FirstOrDevault();
        //}
    }
}