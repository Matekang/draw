using Microsoft.AspNetCore.Mvc;

namespace DrawPicture.Controllers
{
    public class ListImage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
