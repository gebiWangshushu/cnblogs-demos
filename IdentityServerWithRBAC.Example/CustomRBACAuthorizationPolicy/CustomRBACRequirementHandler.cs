using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomRBACAuthorizationPolicy
{
    public class CustomRBACRequirementHandler : AuthorizationHandler<CustomRBACRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomRBACRequirementHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRBACRequirement requirement)
        {
            var subid = context.User?.FindFirst(c=>c.Type== "sub");

            return Task.CompletedTask;
        }
    }
}
