using Logistics.Management.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logistics.Management.Data.Context.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasIndex(e => e.Description, "IX_Order_Description");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Description).HasMaxLength(255);

            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");

            builder.HasOne(d => d.OrderStatus).WithMany(p => p.Orders).HasForeignKey(d => d.OrderStatusId).HasConstraintName("FK_Orders_OrderStatus");
        }
    }
}