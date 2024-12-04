using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DrawPicture.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; }
        public string? Class { get; set; }
    }

}
