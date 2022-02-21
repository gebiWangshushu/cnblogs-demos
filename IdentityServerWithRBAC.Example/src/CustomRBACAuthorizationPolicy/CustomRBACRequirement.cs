using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRBACAuthorizationPolicy
{
    public class CustomRBACRequirement: IAuthorizationRequirement
    {
        public string PolicyName { get; }

        public CustomRBACRequirement(string policyName)
        {
            this.PolicyName = policyName;
        }
    }
}
