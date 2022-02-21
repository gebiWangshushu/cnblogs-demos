using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomRBACAuthorizationPolicy
{
    public class CustomRBACPolicyProvider : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return FallbackPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        {
            return Task.FromResult<AuthorizationPolicy>(null);
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName== Const.PolicyCombineId4ExternalRBAC)
            {
                var policys = new AuthorizationPolicyBuilder();
                policys.AddRequirements(new CustomRBACRequirement(policyName));
                return Task.FromResult(policys.Build());
            }

            return Task.FromResult<AuthorizationPolicy>(null);

        }
    }
}
