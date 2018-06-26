using AdData.Models;
using Microsoft.EntityFrameworkCore;

namespace AdData
{
    public class AdContext : DbContext
    {
        public AdContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
