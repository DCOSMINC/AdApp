using AdData.Models;
using Microsoft.EntityFrameworkCore;

namespace AdData
{
    public class AdContext : DbContext
    {
        public AdContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ad> Ads { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        
    }
}
