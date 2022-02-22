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
            //var endpoint = _httpContextAccessor.HttpContext.GetEndpoint();
            //var descriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
            //var controllerName = descriptor.ControllerName;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRBACRequirement requirement)
        {
            var subid = context.User?.FindFirst(c => c.Type == "sub")?.ToString();
            var routeData = _httpContextAccessor.HttpContext?.GetRouteData();

            var curentAction = routeData?.Values["action"]?.ToString();
            var curentController = routeData?.Values["controller"]?.ToString();
            var apiName = Assembly.GetEntryAssembly().GetName().Name; //入口程序集，用来标识某个api

            if (string.IsNullOrWhiteSpace(subid) == false && string.IsNullOrWhiteSpace(curentAction) == false && string.IsNullOrWhiteSpace(curentController) == false)
            {
                //var
            }

            return Task.CompletedTask;
        }
    }
}