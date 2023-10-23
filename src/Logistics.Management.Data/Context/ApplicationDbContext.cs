using Logistics.Management.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Management.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<AutomatedGuidedVehicle> AutomatedGuidedVehicles { get; set; } = null!;
        public virtual DbSet<Good> Goods { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<RequestItem> RequestItems { get; set; } = null!;
        public virtual DbSet<RequestStatus> RequestStatuses { get; set; } = null!;
        public virtual DbSet<StatusEnum> StatusEnums { get; set; } = null!;

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=logistics-management;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutomatedGuidedVehicle>(entity =>
            {
                entity.ToTable("AutomatedGuidedVehicle");

                entity.HasIndex(e => e.Name, "IX_AutomatedGuidedVehicle_Name");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.AutomatedGuidedVehicles)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Automated__Locat__3B75D760");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.ToTable("Good");

                entity.HasIndex(e => e.Name, "IX_Good_Name");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Good__LocationId__36B12243");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LocationX).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.LocationY).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.HasIndex(e => e.Description, "IX_Request_Description");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.RequestStatus)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.RequestStatusId)
                    .HasConstraintName("FK_Request_RequestStatus");
            });

            modelBuilder.Entity<RequestItem>(entity =>
            {
                entity.ToTable("RequestItem");

                entity.HasIndex(e => e.GoodId, "IX_RequestItem_GoodId");

                entity.HasIndex(e => e.RequestId, "IX_RequestItem_RequestId");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.RequestItems)
                    .HasForeignKey(d => d.GoodId)
                    .HasConstraintName("FK__RequestIt__GoodI__412EB0B6");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestItems)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__RequestIt__Reque__403A8C7D");
            });

            modelBuilder.Entity<RequestStatus>(entity =>
            {
                entity.ToTable("RequestStatus");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestStatuses)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_RequestStatus_Request");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.RequestStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_RequestStatus_StatusEnum");
            });

            modelBuilder.Entity<StatusEnum>(entity =>
            {
                entity.ToTable("StatusEnum");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StatusName).HasMaxLength(255);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}