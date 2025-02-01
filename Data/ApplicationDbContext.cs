using MeeshoClone.Models.User;
using Microsoft.EntityFrameworkCore;

namespace MeeshoClone.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }

    }
}
