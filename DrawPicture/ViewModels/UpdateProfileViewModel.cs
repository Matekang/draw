using System.ComponentModel.DataAnnotations;

namespace DrawPicture.ViewModels
{
    public class UpdateProfileViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên.")]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lớp.")]
        [Display(Name = "Lớp")]
        public string Class { get; set; }
    }
}
