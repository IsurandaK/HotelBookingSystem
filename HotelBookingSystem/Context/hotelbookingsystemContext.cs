//Data Context class
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Context
{
    public partial class hotelbookingsystemContext : DbContext
    {
        public hotelbookingsystemContext()
        {
        }

        public hotelbookingsystemContext(DbContextOptions<hotelbookingsystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("bookings");

                entity.HasIndex(e => e.CustomerId, "IX_Bookings_CustomerID");

                entity.HasIndex(e => e.HotelId, "IX_Bookings_HotelID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.CheckInDate).HasMaxLength(6);

                entity.Property(e => e.CheckOutDate).HasMaxLength(6);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Bookings_Customers_CustomerID");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_Bookings_Hotels_HotelID");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.NicNumber)
                    .HasName("PRIMARY");

                entity.ToTable("customers");

                entity.Property(e => e.NicNumber).HasColumnName("NIC_Number");

                entity.Property(e => e.AddressLine1).IsRequired();

                entity.Property(e => e.AddressLine2).IsRequired();

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Payment).IsRequired();
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("hotels");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.Availability).IsRequired();

                entity.Property(e => e.HotelAddressLine1).IsRequired();

                entity.Property(e => e.HotelAddressLine2).IsRequired();

                entity.Property(e => e.HotelDiscription).IsRequired();
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("rooms");

                entity.HasIndex(e => e.BookingId, "IX_Rooms_BookingID");

                entity.HasIndex(e => e.CustomerId, "IX_Rooms_CustomerID");

                entity.HasIndex(e => e.HotelId, "IX_Rooms_HotelID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.RoomAvailability).IsRequired();

                entity.Property(e => e.RoomType).IsRequired();

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_Rooms_Bookings_BookingID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Rooms_Customers_CustomerID");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_Rooms_Hotels_HotelID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}