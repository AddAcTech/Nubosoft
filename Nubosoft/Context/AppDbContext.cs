using Nubosoft.Models;
using System.Data.Entity;

namespace Nubosoft.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("ApplicationDbContext") { }

        public DbSet<User> Users { get; set; }
    }
}
