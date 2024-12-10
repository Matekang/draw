using System.ComponentModel.DataAnnotations;

namespace DrawPicture.ViewModels
{
    public class ChangePasswordViewModel
    {

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu cũ.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Vui lòng nhập ít nhất là 8 ký tự.")]
        [Display(Name = "Mật khẩu cũ")]
        public string CurrentPassword { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Vui lòng nhập ít nhất là 8 ký tự.")]
        [DataType(DataType.Password)]
        [Compare("ConfimPassword", ErrorMessage = "Mật khẩu không trùng khớp.")]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu mới.")]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu mới")]
        public string ConfimPassword { get; set; }
    }
}
