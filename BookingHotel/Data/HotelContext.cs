﻿using BookingHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomTypeDetail> RoomTypeDetails { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<RoomTypeDetailImage> roomTypeDetailImages { get; set; }
        public DbSet<ComboSale> ComboSales { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<RoomType>().ToTable("RoomType");
            modelBuilder.Entity<RoomTypeDetail>().ToTable("RoomTypeDetail");
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<RoomTypeDetailImage>().ToTable("RoomTypeDetailImage");
            modelBuilder.Entity<ComboSale>().ToTable("ComboSale");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<Request>().ToTable("Request");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        }
    }
}
