using Microsoft.EntityFrameworkCore;
using stoktakip.Models;
using Microsoft.EntityFrameworkCore;

namespace stoktakip.data
{
    public class stoktakipDBContext : DbContext
    {
        public stoktakipDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<users> users { get; set; }
        public DbSet<roles> roles { get; set; }
        public DbSet<orders> orders { get; set; }

        public DbSet<bodinoz> bodinoz { get; set; }

        public DbSet<matbaa> matbaa { get; set; }
        public DbSet<kesim> kesim { get; set; }

        public DbSet<Stok> Stok { get; set; }

        public DbSet<Uretim> Uretim { get; set; }

        public DbSet<permission> permission { get; set; }
        public DbSet<url> url { get; set; }

    }
}
