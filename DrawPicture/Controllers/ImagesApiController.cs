using DrawPicture.Data;
using DrawPicture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DrawPicture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesApiController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ImagesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("save-image")]
        public IActionResult SaveImage([FromBody] ImageRequest request)
        {
            try
            {
                var imageData = Convert.FromBase64String(request.ImageData.Split(',')[1]);
                var originalName = WebUtility.HtmlDecode(request.Name);
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "pictureDrawn");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = $"drawing_{DateTime.Now.Ticks}.jpg";
                var filePath = Path.Combine(folderPath, fileName);
                _context.Add( new DrawStudent()
                {
                    Picture = fileName,
                    UserId = request.UserId,
                    Status = request.Status,
                    Name = originalName,
                    Class = request.Class,
                });
                System.IO.File.WriteAllBytes(filePath, imageData);
                _context.SaveChanges();
                return Ok(new { message = "Hình ảnh đã được lưu thành công", filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lưu hình ảnh", error = ex.Message });
            }
        }

        [HttpPost("image-library")]
        public IActionResult ImageLibrary([FromBody] ImageRequest request)
        {
            try
            {
                var imageData = Convert.FromBase64String(request.ImageData.Split(',')[1]);
                var originalName = WebUtility.HtmlDecode(request.Name);
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "pictureLibrary");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = $"library_{DateTime.Now.Ticks}.jpg";
                var filePath = Path.Combine(folderPath, fileName);

                System.IO.File.WriteAllBytes(filePath, imageData);

                _context.Add(new DrawStudent()
                {
                    Picture = fileName,
                    UserId = request.UserId,
                    Status = request.Status,
                    Name = originalName,
                    Class = request.Class,
                });
                _context.SaveChanges();
                return Ok(new { message = "Hình ảnh đã được lưu thành công", filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lưu hình ảnh", error = ex.Message });
            }
        }

        [HttpPost("like")]
        public async Task<IActionResult> LikePost(string userId, int drawId)
        {
            // Kiểm tra nếu người dùng đã thích bài viết
            var existingLike = await _context.LikeUsers
                .FirstOrDefaultAsync(like => like.UserId == userId && like.DrawId == drawId);

            if (existingLike != null)
            {
                return BadRequest(new { message = "Bạn đã thích bài viết này!" });
            }

            var getDraw = await _context.DrawStudents.FindAsync(drawId);

            getDraw.Like = getDraw.Like + 1;

            // Tạo lượt thích mới
            var newLike = new LikeUser
            {
                UserId = userId,
                DrawId = drawId,
                LikedDate = DateTime.UtcNow
            };

            _context.LikeUsers.Add(newLike);
            _context.DrawStudents.Update(getDraw);

            await _context.SaveChangesAsync();

            return Ok(new { message = "Đã thích bài viết thành công!" });
        }


        public class ImageRequest
        {
            public string ImageData { get; set; }
            public string UserId { get; set; }
            public string Name { get; set; }
            public bool Status { get; set; }
            public string Class { get; set; }
        }

    }
}
