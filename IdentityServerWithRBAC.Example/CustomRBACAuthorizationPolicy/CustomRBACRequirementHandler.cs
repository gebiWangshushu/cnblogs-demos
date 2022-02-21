using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
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
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRBACRequirement requirement)
        {
            var subid = context.User?.FindFirst(c=>c.Type== "sub");
            var httpContext = _httpContextAccessor.HttpContext;

            var currentController= _actionContextAccessor.ActionContext?.RouteData?.Values?["controller"].ToString();
            var currentAction= _actionContextAccessor.ActionContext?.RouteData?.Values?["action"].ToString();

            return Task.CompletedTask;
        }
    }
}
