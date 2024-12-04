using Microsoft.AspNetCore.Mvc;

namespace DrawPicture.Controllers
{
    public class HomeDraw : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
