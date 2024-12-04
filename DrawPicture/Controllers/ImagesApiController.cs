using Microsoft.AspNetCore.Mvc;

namespace DrawPicture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesApiController : Controller
    {
        [HttpPost("save-image")]
        public IActionResult SaveImage([FromBody] ImageRequest request)
        {
            try
            {
                var imageData = Convert.FromBase64String(request.ImageData.Split(',')[1]);

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "pictureDrawn");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = $"drawing_{DateTime.Now.Ticks}.jpg";
                var filePath = Path.Combine(folderPath, fileName);

                System.IO.File.WriteAllBytes(filePath, imageData);

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
        }
    }
}
