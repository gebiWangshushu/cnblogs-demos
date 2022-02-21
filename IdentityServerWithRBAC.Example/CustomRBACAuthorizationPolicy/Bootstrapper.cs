using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRBACAuthorizationPolicy
{
    public static  class Bootstrapper
    {

        /// <summary>
        /// 自定义角色的授权策略
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomRBACAuthorizationPolicy(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAuthorizationPolicyProvider, CustomRBACPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, CustomRBACRequirementHandler>();

            return services;
        }

    }
}
