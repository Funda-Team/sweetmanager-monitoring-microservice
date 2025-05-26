using Microsoft.EntityFrameworkCore;
using MonitoringService.Domain.Model.Aggregates;
using MonitoringService.Domain.Model.Entities;

namespace MonitoringService.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public partial class MonitoringContext : DbContext
    {
        public MonitoringContext() { }

        public MonitoringContext(DbContextOptions<MonitoringContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("bookings");

                entity.HasIndex(e => e.RoomsId, "rooms_id");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Amount)
                    .HasPrecision(10)
                    .HasColumnName("amount");
                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");
                entity.Property(e => e.FinalDate)
                    .HasColumnType("datetime")
                    .HasColumnName("final_date");
                entity.Property(e => e.NightCount).HasColumnName("night_count");
                entity.Property(e => e.PaymentsCustomer).HasColumnName("payments_customer");
                entity.Property(e => e.PriceRoom)
                    .HasPrecision(10)
                    .HasColumnName("price_room");
                entity.Property(e => e.RoomsId).HasColumnName("rooms_id");
                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .HasColumnName("state");

                entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bookings_ibfk_1");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("rooms");

                entity.HasIndex(e => e.TypesRoomsId, "types_rooms_id");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.HotelsId).HasColumnName("hotels_id");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .HasColumnName("state");
                entity.Property(e => e.TypesRoomsId).HasColumnName("types_rooms_id");

                entity.HasOne(d => d.TypesRoom).WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.TypesRoomsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rooms_ibfk_1");
            });

            modelBuilder.Entity<TypeRoom>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("types_rooms");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");
                entity.Property(e => e.Price)
                    .HasPrecision(10)
                    .HasColumnName("price");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}