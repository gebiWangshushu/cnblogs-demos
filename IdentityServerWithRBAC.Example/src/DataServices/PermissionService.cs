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
    /// 权限信息（实际上这些应该存在数据库）
    /// </summary>
    public static List<PermissionEntity> Permissions = new List<PermissionEntity>
    {
        //RoleId R01 是管理员,有两个Api的多个接口的权限
        new PermissionEntity{ PermissionId="0001",RoleId="R01", ApiName="Hei.UserApi",Authorised=new Dictionary<string, List<string>>
            {
                { "Profile",new List<string>{ "GetUsername"}},
                { "Credit",new List<string>{ "GetScore"}},
            }
        },
        new PermissionEntity{ PermissionId="0002",RoleId="R01", ApiName="Hei.OrderApi",Authorised=new Dictionary<string, List<string>>
            {
                { "Delivery",new List<string>{ "GetAddress"}},
                { "Order",new List<string>{ "GetOrderNo"}},
            }
        },

        //RoleId R02 是普通员工,有两个Api的多个 部分 接口的权限
        new PermissionEntity{ PermissionId="0001",RoleId="R02", ApiName="Hei.UserApi",Authorised=new Dictionary<string, List<string>>
            {
                { "Profile",new List<string>{ "GetUsername"}},
                //{ "Credit",new List<string>{ "GetScore"}}, //用户信用分接口权限就不给普通员工了
            }
        },
        new PermissionEntity{ PermissionId="0002",RoleId="R02", ApiName="Hei.OrderApi",Authorised=new Dictionary<string, List<string>>
            {
                //{ "Delivery",new List<string>{ "GetAddress"}}, //用户地址信息也是
                { "Order",new List<string>{ "GetOrderNo"}},
            }
        }
    };

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
                    //获取用户角色id
                    var rid = ridClaim.Value;
                    var rolePermission = Permissions.FirstOrDefault(c => c.ApiName == apiName && c.RoleId == rid);

                    return rolePermission;
                }
            }

            return null;
        }
    }
}