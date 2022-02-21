using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRBACAuthorizationPolicy
{
    /// <summary>
    /// 使用自定义权限划分的接口打这个标签
    /// </summary>
    public class CustomRBACAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomRBACAuthorizeAttribute(string policyName="")
        {
            this.PolicyName = policyName;
        }

        public string PolicyName
        {
            get
            {
                return PolicyName;
            }
            set
            {
                Policy = $"{Const.PolicyCombineId4ExternalRBAC}{value.ToString()}";
            }
        }
    }
}
