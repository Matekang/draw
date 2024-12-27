using Microsoft.AspNetCore.Mvc;
using System;

namespace DrawPicture.Controllers
{
    public class DrawingPictureController : Controller
    {
        public IActionResult ColorPicture()
        {
            return View();
        }

        public IActionResult FreeDrawing(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                return RedirectToAction("Index");
            }
            string[] content = new string[5];
            string result = "";
            switch (topic.ToString())
            {
                case "chude1_hk1":
                    content = new string[6];

                    content[0] = "Chủ đề 1: Trường em:";
                    content[1] = "- Tên em là gì? hãy trang trí tên của mình thật đẹp nhé!";
                    content[2] = "- Các em chơi gì vào giờ ra chơi?";
                    content[3] = "- Hình ảnh lớp học trong tiết học mà em yêu thích";
                    content[4] = "- Chân dung người bạn mà em yêu quý";
                    content[5] = "-Trò chơi yêu thích của em với bạn bè.";
                    result = GetContentRandom(content);
                    break;

                //case "chude1_hk2":
                //    content = @"Chủ đề 1: Tranh dân gian
                //                -Em hãy vẽ một chú gà trong tranh Đông Hồ với các đường nét và màu sắc mà em thích.
                //                -Trong làng quê có những gì? (cây đa, giếng nước, đồng lúa...). Em hãy vẽ lại bức tranh làng quê dân gian theo trí tưởng tượng của mình.
                //                -Em hãy chọn một họa tiết đơn giản trong tranh dân gian (hoa lá, con cá, con trâu) và tô màu thật đẹp.
                //                -Hãy tưởng tượng một bức tranh dân gian nói về ngày hội ở trường em, sử dụng màu sắc tươi sáng như tranh Đông Hồ
                //                ";
                //    break;
                case "chude2_hk1":
                    content = new string[6];

                    content[0] = "Chủ đề 2: Mùa thu quê em";
                    content[1] = "-Vẽ mặt nạ trung thu hình động vật";
                    content[2] = "-Vẽ mặt nạ trung thu dựa theo nhân vật hoạt hình mà em yêu thích";
                    content[3] = "-Khung cảnh mùa thu quê em";
                    content[4] = "-Vẽ mặt nạ trung thu dựa theo hình người";
                    content[5] = "-Vẽ phong cảnh đêm trung thu ở địa phương em";
                    result = GetContentRandom(content);
                    break;
                //case "chude2_hk2":
                //    content = @"Chủ đề 2: Những con vật ngộ nghĩnh
                //                -Em hãy vẽ một con vật mà em thường thấy trên cánh đồng, ví dụ như trâu, bò, hoặc vịt.
                //                -Em hãy vẽ một bức tranh về khu rừng với các con vật mà em thích (hươu, khỉ, voi...).
                //                -Em hãy tưởng tượng và vẽ một loài vật vừa biết bay vừa biết bơi. Nó sẽ có hình dáng như thế nào?
                //                ";
                //    break;
                case "chude3_hk1":
                    content = new string[6];

                    content[0] = "Chủ đề 3: Mái ấm gia đình";
                    content[1] = "-Vẽ một đồ vật thân quen trong gia đình em (bàn ăn, Tivi, ghế,...)";
                    content[2] = "-Vẽ chân dung một thành viên trong gia đình em";
                    content[3] = "-Vẽ lại bức tranh gia đình em trong chuyến đi chơi gần đây";
                    content[4] = "-Em thích hoạt động nào nhất trong ngày cùng với gia đình";
                    content[5] = "-Vẽ bức tranh về tất cả các thành viên trong gia đình em";
                    result = GetContentRandom(content);
                    break;
                //case "chude3_hk2":
                //    content = @"Chủ đề 3: Người thân của em
                //                -Vẽ chân dung một thành viên trong gia đình mà em yêu quý nhất.
                //                -Vẽ bức tranh cả gia đình quây quần trong bữa cơm.
                //                -Tưởng tượng một chuyến đi chơi cùng gia đình và vẽ lại khoảnh khắc đó.
                //                -Vẽ một bức tranh về món quà mà em muốn tặng cho người thân của mình.
                //                -Vẽ hình ảnh người thân của em trong một hoạt động thường ngày (nấu ăn, đọc sách, v.v.).
                //                ";
                //    break;
                case "chude4_hk1":
                    content = new string[5];

                    content[0] = "Chủ đề 4: Góc học tập của em";
                    content[1] = "-Vẽ một chậu hoa với loài hoa mà em yêu thích";
                    content[2] = "-Con vật em yêu thích là gì?";
                    content[3] = "-Hãy thiết kế một hộp đựng bút mà em mơ ước nhé!";
                    content[4] = "-Loài hoa em yêu thích là gì?";
                    result = GetContentRandom(content);
                    break;
                //case "chude4_hk2":
                //    content = @"Chủ đề 4: Thiên nhiên
                //                -Vẽ một bức tranh phong cảnh thiên nhiên mà em yêu thích (núi non, biển cả, cánh đồng).
                //                -Vẽ lại một hiện tượng thiên nhiên như mưa, cầu vồng, hoàng hôn hoặc bão.
                //                -Sáng tạo một khu vườn nhỏ với các loài cây, hoa và côn trùng mà em yêu quý.
                //                -Tưởng tượng một khu rừng thần tiên và vẽ lại những chi tiết thú vị trong đó.
                //                ";
                //    break;
                case "chude5_hk1":
                    content = new string[6];

                    content[0] = "Chủ đề 5: Khu vườn nhỏ";
                    content[1] = "- Loài cây em yêu thích là gì?";
                    content[2] = "- Hãy viết loài cây em yêu thích!";
                    content[3] = "- Em thường bắt gặp con côn trùng nào trong vườn?";
                    content[4] = "- Em hãy vẽ lại loài côn trùng ấy nhé!";
                    content[5] = "- Em hãy thiết kế một khu vườn có loài cây và loài côn trùng em yêu quý!";
                    result = GetContentRandom(content);
                    break;
                //case "chude5_hk2":
                //    content = @"Chủ đề 5: Ngôi trường của em 
                //                -Vẽ lại hình ảnh sân trường với hàng cây, cột cờ và các bạn đang vui chơi.
                //                -Tưởng tượng lớp học của em và vẽ lại hình ảnh thầy cô, bạn bè trong một tiết học.
                //                -Vẽ hình ảnh hoạt động giờ ra chơi của các bạn trong trường.
                //                -Tưởng tượng một ngôi trường trong tương lai và vẽ lại các ý tưởng sáng tạo của em.
                //                -Vẽ hình ảnh một góc đặc biệt trong trường mà em yêu thích nhất.
                //                ";
                //    break;
                //case "chude6_hk2":
                //    content = @"Chủ đề 6: Chuyến đi kỳ thú
                //                -Trong chuyến đi chơi gần đây, em bắt gặp cảnh vật/lễ hội/con người tuyệt đẹp nào?
                //                -Những cảnh vật/lễ hội/con người đẹp đẽ đó có những màu sắc gì?
                //                -Em hãy vẽ lại khung cảnh ấy nhé!
                //                -Em đã đi bảo tàng bao giờ chưa?
                //                -Tại bảo tàng em đặc biệt thích thú với mô hình nào? Em hãy vẽ mô phỏng lại hiện vật đó nhé!
                //                ";
                //    break;
                case "chude6_hk1":
                    content = new string[7];

                    content[0] = "Chủ đề 6: Đô thị ngày nay";
                    content[1] = "-Em từng thấy những toà nhà có hình thù nào rồi? (gợi ý: có thể là ngoài đời hoặc trong phim ảnh, toà nhà có thể hình tròn như trứng hoặc hình trái tim…)";
                    content[2] = "-Em thấy nhà cao tầng có mấy tầng? Chúng có màu gì?";
                    content[3] = "-Em thường thấy dụng cụ, thiết bị gì trong khu vui chơi?";
                    content[4] = "-Em thường tham gia hoạt động gì trong khu vui chơi?";
                    content[5] = "-Em có ấn tượng với khu nhà hay khu đô thị nào?";
                    content[6] = "-Em hãy sáng tạo khu đô thị của riêng mình nhé!";
                    result = GetContentRandom(content);
                    break;
                //case "chude7_hk2":
                //    content = @"Chủ đề 7: Ước mơ của em 
                //                -Em biết những nghề nghiệp nào?
                //                -Sở trường của em là gì? Sở thích của em là gì?
                //                -Sau này em ước mơ làm nghề gì?
                //                -Để làm nghề đó, em sẽ cần những thiết bị, dụng cụ hỗ trợ nào?
                //                -Em hãy vẽ hình ảnh bản thân khi làm nghề đó như thế nào nhé!
                //                ";
                //    break;
                default:
                    result = "Chủ đề không hợp lệ.";
                    break;
            }

            
            ViewBag.Content = result;
            return View();
        }

        public string GetContentRandom(string[] content)
        {
            Random random = new Random();
            if (content == null || content.Length == 0)
            {
                throw new ArgumentException("Mảng content không được null hoặc rỗng.");
            }

            int index = random.Next(0, content.Length); // Giới hạn từ 0 đến content.Length - 1
            return content[index];
        }
    }
}
