using Microsoft.EntityFrameworkCore;
using Wearhouse3.Class;
namespace Wearhouse3.Data
{
    public class WearhouseDbContext : DbContext
    {
        public WearhouseDbContext(DbContextOptions<WearhouseDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<Category> Category { get; set; }
    }
}
