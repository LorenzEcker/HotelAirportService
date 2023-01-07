using HotelAirportService.Domain;
using HotelAirportService.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelAirportService.DataAccess.seeding;

namespace HotelAirportService.DataAccess.context
{
    public class HotelAirportServiceContext : DbContext
    {
        public HotelAirportServiceContext(DbContextOptions<HotelAirportServiceContext> options) : base(options)
        {
        }

        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Ride> Ride { get; set; }


        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is HotelAirportServiceBaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((HotelAirportServiceBaseEntity)entity.Entity).CreatedAt = now;
                }
                ((HotelAirportServiceBaseEntity)entity.Entity).LastModified = now;
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Airport>(entity =>
            {
                entity.HasMany(a => a.Rides)
                    .WithOne(r => r.Airport)
                    .HasForeignKey(r => r.AirportId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Booking>(entity =>
            {
                entity.HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            //builder.Entity<Customer>(entity =>
            //{

            //});

            //builder.Entity<Driver>(entity =>
            //{

            //});

            //builder.Entity<Flight>(entity =>
            //{

            //});

            builder.Entity<Ride>(entity =>
            {
                entity.HasOne(r => r.Customer)
                .WithMany(c => c.Rides)
                .HasForeignKey(r => r.CustomerId);

                entity.HasOne(r => r.Driver)
                .WithMany(d => d.Rides)
                .HasForeignKey(r => r.DriverId);
            });
        }
    }
}
