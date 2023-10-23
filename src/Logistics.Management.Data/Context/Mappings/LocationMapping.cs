using Logistics.Management.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logistics.Management.Data.Context.Mappings
{
    public class LocationMapping : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

            builder.Property(e => e.LocationX).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.LocationY).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");
        }
    }
}