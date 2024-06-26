﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BadmintonRentingData.Model
{
    public partial class Net1702_PRN221_BadmintonRentingContext : DbContext
    {
        public Net1702_PRN221_BadmintonRentingContext()
        {
        }

        public Net1702_PRN221_BadmintonRentingContext(DbContextOptions<Net1702_PRN221_BadmintonRentingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BadmintonField> BadmintonFields { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingBadmintonFieldSchedule> BookingBadmintonFieldSchedules { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=12345;database=Net1702_PRN221_BadmintonRenting;TrustServerCertificate=True;");
        //    }
        //}

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];

            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BadmintonField>(entity =>
            {
                entity.ToTable("BadmintonField");

                entity.Property(e => e.BadmintonFieldId).HasColumnName("BadmintonFieldID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BadmintonFieldName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);


                entity.Property(e => e.IsActive)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .IsFixedLength();

            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingType)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.IsStatus)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__UserId__398D8EEE");
            });

            modelBuilder.Entity<BookingBadmintonFieldSchedule>(entity =>
            {
                entity.HasKey(e => e.OrderBadmintonFieldScheduleId)
                    .HasName("PK__Booking___750D09A5A8EEFC40");

                entity.ToTable("Booking_BadmintonField_Schedule");

                entity.Property(e => e.OrderBadmintonFieldScheduleId).HasColumnName("OrderBadmintonFieldScheduleID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.BadmintonFieldNavigation)
                    .WithMany(p => p.BookingBadmintonFieldSchedules)
                    .HasForeignKey(d => d.BadmintonField)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking_B__Badmi__412EB0B6");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingBadmintonFieldSchedules)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking_B__Booki__403A8C7D");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.BookingBadmintonFieldSchedules)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking_B__Sched__4222D4EF");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsStatus)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.EndTimeFrame).HasColumnType("date");

                entity.Property(e => e.ScheduleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StartTimeFrame).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
