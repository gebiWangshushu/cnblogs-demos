using CustomRBACAuthorizationPolicy;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hei.OrderApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [CustomRBACAuthorize]
        public string GetOrderNo(string id)
        {
            return "Order_10011";
        }
    }
}