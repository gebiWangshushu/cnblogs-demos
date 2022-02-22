﻿using DataServices;
using IdentityModel;
using IdentityServer4.Validation;
using IdentityServerHost.Quickstart.UI;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public CustomResourceOwnerPasswordValidator()
        {
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (!string.IsNullOrEmpty(context.UserName) && !string.IsNullOrEmpty(context.Password))
            {
                var loginUser = UserService.Users.First(c => c.Username == context.UserName && c.Password == context.Password);

                if (loginUser != null)
                {
                    context.Result = new GrantValidationResult(loginUser.SubjectId, OidcConstants.AuthenticationMethods.Password);
                    return Task.CompletedTask;
                }
            }
            return Task.CompletedTask;
        }
    }
}