using Many2Many.Models;
using Microsoft.EntityFrameworkCore;

namespace Many2Many
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public  DbSet<Student> Students { get; set; }
        public  DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-K5TJS8VR\\SQLEXPRESS;Database=EFcore;Integrated Security=SSPI;Application Name=EntityFramework");
            }
        }
    }
}
