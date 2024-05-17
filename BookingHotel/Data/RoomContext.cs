using BookingHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Data
{
    public class RoomContext : DbContext
    {
        public RoomContext(DbContextOptions<RoomContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomTypeDetail> RoomTypeDetails { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<RoomTypeDetailImage> roomTypeDetailImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<RoomType>().ToTable("RoomType");
            modelBuilder.Entity<RoomTypeDetail>().ToTable("RoomTypeDetail");
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<RoomTypeDetailImage>().ToTable("RoomTypeDetailImage");
        }
    }
}
