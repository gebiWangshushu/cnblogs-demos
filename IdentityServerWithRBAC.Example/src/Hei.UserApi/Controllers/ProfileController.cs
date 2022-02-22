using CustomRBACAuthorizationPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hei.UserApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [CustomRBACAuthorize]
        public string GetUsername(string id)
        {
            return "王小明";
        }

        /// <summary>
        /// 获取用户昵称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetNickname(string id)
        {
            return "明明~~";
        }
    }
}