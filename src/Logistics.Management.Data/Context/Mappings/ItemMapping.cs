using Logistics.Management.Data.Entities;
using Logistics.Management.Data.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logistics.Management.Data.Context.Mappings
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasIndex(e => e.Name, "IX_Items_Name");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Name).HasMaxLength(255);

            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");

            builder.HasOne(d => d.Location).WithMany(p => p.Items).HasForeignKey(d => d.LocationId).HasConstraintName("FK__Items__LocationI__36B12243");
        }
    }
}