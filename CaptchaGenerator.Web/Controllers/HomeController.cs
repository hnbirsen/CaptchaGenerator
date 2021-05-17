using System.IO;
using CaptchaGenerator.Core;
using CaptchaGenerator.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaptchaGenerator.Web.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("")]
        [HttpPost]
        public IActionResult Index(string captchaCode)
        {
            if (!Generator.ValidateCaptchaCode(captchaCode, HttpContext))
                return Json(new ApiResponse { success = false, error = "Capthca Code is wrong." });

            return Json(new ApiResponse { success = true });
        }

        [Route("getcaptchaimage")]
        public FileStreamResult GetCaptchaImage()
        {
            int width = 139;
            int height = 50;

            var captchaCode = Generator.GenerateCaptchaCode();
            var result = Generator.GenerateCaptchaImage(width, height, captchaCode);

            HttpContext.Session.SetString("CaptchaCode", result.code);

            var stream = new MemoryStream(result.byteData);
            return new FileStreamResult(stream, "image/png");
        }
    }
}
