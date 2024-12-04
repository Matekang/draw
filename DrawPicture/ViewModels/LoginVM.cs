using System.ComponentModel.DataAnnotations;

namespace DrawPicture.ViewModels;
public class LoginVM
{
    [Required(ErrorMessage = "Vui lòng nhập tài khoản.")]
    [Display(Name = "Tài khoản")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
    [Display(Name = "Mật khẩu")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Ghi nhớ đăng nhập.")]
    public bool RememberMe { get; set; }
}
