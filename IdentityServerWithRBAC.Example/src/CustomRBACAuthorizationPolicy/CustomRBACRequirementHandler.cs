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
        private readonly IActionContextAccessor _actionContextAccessor;

        public CustomRBACRequirementHandler(IHttpContextAccessor httpContextAccessor, IActionContextAccessor actionContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _actionContextAccessor = actionContextAccessor;
        }

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
                var userPermission = PermissionService.GetUserPermissionBySubid(apiName, subid);
                if (userPermission != null)
                {
                    var authActions = userPermission.Authorised?[curentController];
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