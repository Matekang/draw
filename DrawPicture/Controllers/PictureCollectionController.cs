using DrawPicture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrawPicture.Controllers
{
    public class PictureCollectionController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PictureCollectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ShowMyPicture(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("UserId không hợp lệ.");
            }

            var items = await _context.DrawStudents
                                      .Where(i => i.UserId == userId && i.Status == false)
                                      .ToListAsync();

            if (items == null || !items.Any())
            {
                return NotFound("Không có hình ảnh nào phù hợp với yêu cầu.");
            }

            return View(items);
        }

        public async Task<IActionResult> DisplayCollection()
        {
            var items =await _context.DrawStudents.Where(i => i.Status == true).ToListAsync();

            return View(items);
        }
    }
}
