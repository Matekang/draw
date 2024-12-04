using Microsoft.AspNetCore.Mvc;

namespace DrawPicture.Controllers
{
    public class DrawingPictureController : Controller
    {
        public IActionResult FreeDrawing()
        {
            return View();
        }

        public IActionResult ColorPicture()
        {
            return View();
        }
    }
}
