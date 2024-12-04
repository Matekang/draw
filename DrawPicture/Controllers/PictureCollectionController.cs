using Microsoft.AspNetCore.Mvc;

namespace DrawPicture.Controllers
{
    public class PictureCollectionController : Controller
    {
        public IActionResult ShowMyPicture()
        {
            var imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "topic");

            if (!Directory.Exists(imageFolderPath))
            {
                return View(new List<string>());
            }

            var directories = Directory.GetDirectories(imageFolderPath)
                                       .Select(folder => $"{Path.GetFileName(folder)}")
                                       .ToList();

            return View(directories);
        }

        public IActionResult DisplayCollection()
        {
            var imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "topic");

            if (!Directory.Exists(imageFolderPath))
            {
                return View(new List<string>());
            }

            var directories = Directory.GetDirectories(imageFolderPath)
                                       .Select(folder => $"{Path.GetFileName(folder)}")
                                       .ToList();

            return View(directories);
        }
    }
}
