using Logistics.Management.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logistics.Management.Data.Context.Mappings
{
    public class AutomatedGuidedVehicleMapping : IEntityTypeConfiguration<AutomatedGuidedVehicle>
    {
        public void Configure(EntityTypeBuilder<AutomatedGuidedVehicle> builder)
        {
            builder.ToTable("AutomatedGuidedVehicles");

            builder.HasIndex(e => e.Name, "IX_AutomatedGuidedVehicles_Name");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Name).HasMaxLength(255);

            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");

            builder.HasOne(d => d.Location).WithMany(p => p.AutomatedGuidedVehicles).HasForeignKey(d => d.LocationId).HasConstraintName("FK__Automated__Locat__3B75D760");
        }
    }
}