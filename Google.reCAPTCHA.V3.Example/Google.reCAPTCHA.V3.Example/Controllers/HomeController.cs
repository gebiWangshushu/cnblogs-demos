using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.reCAPTCHA.V3.Example.Models;
using reCAPTCHA.AspNetCore;

namespace Google.reCAPTCHA.V3.Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecaptchaService _recaptcha;

        public HomeController(IRecaptchaService recaptcha)
        {
            _recaptcha = recaptcha;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var recaptchaReault = await _recaptcha.Validate(model.GoogleToken);

                if (!recaptchaReault.success || recaptchaReault.score < 0.08m)
                 //if (!recaptchaReault.success || recaptchaReault.score<1)
                {
                    ModelState.AddModelError(string.Empty, "老实说，你是不是机器人！");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "登录成功~");
                }
            }

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
