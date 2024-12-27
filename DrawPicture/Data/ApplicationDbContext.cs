using DrawPicture.Models;
using Microsoft.EntityFrameworkCore;

namespace DrawPicture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        { 
        }

        public DbSet<DrawStudent> DrawStudents { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<LikeUser> LikeUsers { get; set; }
    }
}
