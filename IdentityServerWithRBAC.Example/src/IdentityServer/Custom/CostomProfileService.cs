using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Custom
{
    public class CostomProfileService : IProfileService
    {
        private readonly ILogger _logger;

        public CostomProfileService(ILogger logger)
        {
            _logger = logger;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var claims = context.Subject.Claims.ToList();
                context.IssuedClaims = claims;
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetProfileDataAsync异常.{ex.Message}{ex.StackTrace}");
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }
}