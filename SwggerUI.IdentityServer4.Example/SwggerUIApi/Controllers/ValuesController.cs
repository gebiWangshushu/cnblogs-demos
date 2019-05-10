using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SwggerUIApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// 这是一个啥都没干的接口
        /// </summary>
        /// <returns></returns>
        [HttpGet] [Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
