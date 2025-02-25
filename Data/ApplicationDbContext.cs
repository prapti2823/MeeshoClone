using MeeshoClone.Models.Category;
using MeeshoClone.Models.Supplier;
using MeeshoClone.Models.User;
using Microsoft.EntityFrameworkCore;

namespace MeeshoClone.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //string hashedPassword = BCrypt.Net.BCrypt.HashPassword("prapti@12");

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "Prapti Shah", Username = "prapti",Email = "praptishah2823@gmail.com",Password = BCrypt.Net.BCrypt.HashPassword("prapti@12"), CreatedDate = new DateTime(2024, 2, 10, 0, 0, 0, DateTimeKind.Utc), Role = "Admin",IsActive = true, MobileNumber = "1234567890" }
                );
        }

        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}
