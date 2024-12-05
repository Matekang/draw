using Microsoft.AspNetCore.Mvc;

namespace DrawPicture.Controllers
{
    public class PictureCollectionController : Controller
    {
        public IActionResult ShowMyPicture()
        {
            var imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "pictureDrawn");

            if (!Directory.Exists(imageFolderPath))
            {
                return View(new List<string>());
            }

            var imageFiles = Directory.GetFiles(imageFolderPath)
                                       .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                      file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                                      file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                                      file.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                                       .Select(file => Path.GetFileName(file))
                                       .ToList();

            return View(imageFiles);
        }


        public IActionResult DisplayCollection()
        {
            var imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "pictureLibrary");

            if (!Directory.Exists(imageFolderPath))
            {
                return View(new List<string>());
            }

            var imageFiles = Directory.GetFiles(imageFolderPath)
                                       .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                      file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                                      file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                                      file.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                                       .Select(file => Path.GetFileName(file))
                                       .ToList();

            return View(imageFiles);
        }
    }
}
