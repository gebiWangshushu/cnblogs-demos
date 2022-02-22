using DataServices.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataServices
{
    public class PermissionService
    {
        /// <summary>
        /// 获取用户在指定apiName拥有的权限
        /// </summary>
        /// <param name="apiName"></param>
        /// <param name="subid"></param>
        /// <returns></returns>
        public static PermissionEntity GetUserPermissionBySubid(string apiName, string subid)
        {
            var user = UserService.Users.FirstOrDefault(c => c.SubjectId == subid);
            if (user != null)
            {
                var ridClaim = user.Claims.FirstOrDefault(c => c.Type == "rid");
                if (ridClaim != null)
                {
                    var rid = ridClaim.Value;
                    //var role=RoleService.GetUserPermissionBySubid(apiName, );
                }
            }

            return null;
        }
    }
}