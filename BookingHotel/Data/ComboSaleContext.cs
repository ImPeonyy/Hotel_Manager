using BookingHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Data
{
    public class ComboSaleContext : DbContext
    {
        public ComboSaleContext(DbContextOptions<ComboSaleContext> options) : base(options)
        {
        }

        public DbSet<ComboSale> ComboSales { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComboSale>().ToTable("ComboSale");
        }
    }
}
