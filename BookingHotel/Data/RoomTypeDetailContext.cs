using BookingHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Data
{
    public class RoomTypeDetailContext : DbContext
    {
        public RoomTypeDetailContext(DbContextOptions<RoomTypeDetailContext> options) : base(options)
        {
        }
        public DbSet<RoomTypeDetail> RoomTypeDetails { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<RoomTypeDetailImage> RoomTypeDetailImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomTypeDetail>().ToTable("RoomTypeDetail");
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<Service>().ToTable("RoomTypeDetailImage");
        }
    }
}
