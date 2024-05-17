using BookingHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<Request>().ToTable("Request");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        }
    }
}
