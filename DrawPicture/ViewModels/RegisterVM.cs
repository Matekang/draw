using System.ComponentModel.DataAnnotations;

namespace DrawPicture.ViewModels;

public class RegisterVM
{
    [Required(ErrorMessage = "Vui lòng nhập tên.")]
    [Display(Name = "Họ và tên")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập lớp.")]
    [Display(Name = "Lớp")]
    public string Class { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập.")]
    [Display(Name = "Tài khoản")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
    [StringLength(40, MinimumLength = 8, ErrorMessage = "Vui lòng nhập ít nhất là 8 ký tự.")]
    [DataType(DataType.Password)]
    [Compare("ConfimPassword", ErrorMessage = "Mật khẩu không trùng khớp.")]
    [Display(Name = "Mật khẩu")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu.")]
    [DataType(DataType.Password)]
    [Display(Name = "Nhập lại mật khẩu")]
    public string ConfimPassword { get; set; }
}
