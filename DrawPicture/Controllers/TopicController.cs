using Microsoft.AspNetCore.Mvc;

namespace DrawPicture.Controllers
{
    public class TopicController : Controller
    {
        public IActionResult Index()
        {
            // Đường dẫn đến thư mục 'topic'
            var imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "topic");

            // Kiểm tra xem thư mục có tồn tại không
            if (!Directory.Exists(imageFolderPath))
            {
                return View(new List<string>()); // Trả về danh sách rỗng nếu thư mục không tồn tại
            }

            // Lấy danh sách các thư mục con (folders)
            var directories = Directory.GetDirectories(imageFolderPath)
                                       .Select(folder => $"{Path.GetFileName(folder)}") // Chỉ lấy tên thư mục
                                       .ToList();

            return View(directories);
        }

        public IActionResult Selection()
        {
            // Đường dẫn đến thư mục 'topic'
            var imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "topic");

            // Kiểm tra xem thư mục có tồn tại không
            if (!Directory.Exists(imageFolderPath))
            {
                return View(new List<string>()); // Trả về danh sách rỗng nếu thư mục không tồn tại
            }

            // Lấy danh sách các thư mục con (folders)
            var directories = Directory.GetDirectories(imageFolderPath)
                                       .Select(folder => $"{Path.GetFileName(folder)}") // Chỉ lấy tên thư mục
                                       .ToList();

            return View(directories);
        }

        public IActionResult TopicGallery(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                return RedirectToAction("Index");
            }

            // Đường dẫn folder chứa hình ảnh
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/topic", topic);

            // Lấy danh sách ảnh từ folder
            var images = Directory.Exists(folderPath)
                ? Directory.GetFiles(folderPath, "*.jpg").Select(Path.GetFileName).ToList()
                : new List<string>();

            ViewBag.Topic = topic;
            return View(images); // Truyền danh sách ảnh vào View
        }

    }
}
