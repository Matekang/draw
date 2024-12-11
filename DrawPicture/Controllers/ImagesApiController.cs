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
