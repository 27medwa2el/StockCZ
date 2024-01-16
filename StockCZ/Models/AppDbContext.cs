using Microsoft.EntityFrameworkCore;
using StockCZ.Models.Domain;
using static System.Formats.Asn1.AsnWriter;

namespace StockCZ.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockMovement>()
                .HasOne(sm => sm.Store)
                .WithMany(s => s.StockMovements)
                .HasForeignKey(sm => sm.StoreId);

            modelBuilder.Entity<StockMovement>()
                .HasOne(sm => sm.Item)
                .WithMany(i => i.StockMovements)
                .HasForeignKey(sm => sm.ItemId);
        }
    }
}
