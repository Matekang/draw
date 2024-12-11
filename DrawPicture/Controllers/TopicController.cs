using DrawPicture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrawPicture.Controllers
{
    public class TopicController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TopicController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _context.Pictures.Where(i => i.Folder == null).ToListAsync();

            return View(items);
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

        public IActionResult TopicGallery(string topic , string name)
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
            ViewBag.Name = name;
            return View(images); // Truyền danh sách ảnh vào View
        }

    }
}
