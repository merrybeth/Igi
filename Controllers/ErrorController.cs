using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class ErrorController: Controller
    {
        [Route("/Error")]
        public IActionResult Error([FromQuery] string text_main,[FromQuery]string text)
        {
            TempData["text"] = text;
            TempData["text_main"] = text_main;
            return View();
        }
    }
}