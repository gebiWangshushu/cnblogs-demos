using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataServices;
using System.Linq;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace CustomRBACAuthorizationPolicy
{
    public class CustomRBACRequirementHandler : AuthorizationHandler<CustomRBACRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomRBACRequirementHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 处理CustomRBACRequirement的逻辑
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRBACRequirement requirement)
        {
            var subid = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var routeData = _httpContextAccessor.HttpContext?.GetRouteData();

            var curentAction = routeData?.Values["action"]?.ToString();
            var curentController = routeData?.Values["controller"]?.ToString();

            //入口程序集，用来标识某个api
            var apiName = Assembly.GetEntryAssembly().GetName().Name;

            if (string.IsNullOrWhiteSpace(subid) == false && string.IsNullOrWhiteSpace(curentAction) == false && string.IsNullOrWhiteSpace(curentController) == false)
            {
                //核心就在这里了，查出用户subid对应的角色权限，然后做处理判断有没有当前接口的权限
                //我这里是demo就简单的模拟下，真实的权限数据应该都是写数据库或接口的
                var userPermission = PermissionService.GetUserPermissionBySubid(apiName, subid);
                if (userPermission != null && userPermission.Authorised.ContainsKey(curentController))
                {
                    var authActions = userPermission.Authorised[curentController];

                    //这里判断当前用户的角色有当前action/controllers的权限
                    //(真实的权限划分由你自己定义，比如你划分了只读接口，只写接口、特殊权限接口、内部接口等，在管理后台上分组，打标签/标记然后授予角色就行)
                    if (authActions?.Any(action => action == curentAction) == true)
                    {
                        context.Succeed(requirement);
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}