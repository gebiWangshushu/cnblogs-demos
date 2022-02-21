using CustomRBACAuthorizationPolicy;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hei.OrderApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        /// <summary>
        /// 获取派送地址
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        [HttpGet]
        [CustomRBACAuthorize]
        public string GetAddress(string orderNo)
        {
            return "广州天河小蛮腰808号";
        }
    }
}