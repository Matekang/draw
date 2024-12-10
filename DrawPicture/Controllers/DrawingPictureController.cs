using Microsoft.AspNetCore.Mvc;

namespace DrawPicture.Controllers
{
    public class DrawingPictureController : Controller
    {
        public IActionResult ColorPicture()
        {
            return View();
        }

        public IActionResult FreeDrawing()
        {
            return View();
        }
    }
}
