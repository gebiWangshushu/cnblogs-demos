using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hei.UserApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        /// <summary>
        /// 获取信用分
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public int GetScore(string id)
        {
            return 666;
        }
    }
}