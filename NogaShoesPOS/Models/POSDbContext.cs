using Microsoft.EntityFrameworkCore;

namespace NogaShoesPOS.Models
    {

    public class POSDbContext : DbContext
        {
        public POSDbContext(DbContextOptions<POSDbContext> options)
            : base(options)
            {
            }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cash> Cashes { get; set; }
        }
    }


