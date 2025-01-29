using Logistics.Management.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logistics.Management.Data.Context.Mappings
{
    public class OrderStatusMapping : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("OrderStatus");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");

            builder.Property(e => e.TimeSpent);

            builder.HasOne(d => d.Order).WithMany(p => p.OrderStatuses).HasForeignKey(d => d.OrderId).HasConstraintName("FK_OrderStatus_Order");

            builder.HasOne(d => d.Status).WithMany(p => p.OrderStatuses).HasForeignKey(d => d.StatusId).HasConstraintName("FK_OrderStatus_StatusEnum");
        }
    }
}