using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomRBACAuthorizationPolicy
{
    public class CustomRBACPolicyProvider : IAuthorizationPolicyProvider
    {
        private readonly IConfiguration _configuration;
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

        public CustomRBACPolicyProvider(IConfiguration configuration, IOptions<AuthorizationOptions> options)
        {
            _configuration = configuration;
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }


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
            if (policyName.StartsWith(Const.PolicyCombineId4ExternalRBAC, StringComparison.OrdinalIgnoreCase))
            {
                var policys = new AuthorizationPolicyBuilder();
                policys.AddRequirements(new CustomRBACRequirement(policyName.Replace(Const.PolicyCombineId4ExternalRBAC,"")));
                return Task.FromResult(policys.Build());
            }

            return Task.FromResult<AuthorizationPolicy>(null);

        }
    }
}
