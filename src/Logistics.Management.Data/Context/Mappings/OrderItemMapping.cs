using Logistics.Management.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logistics.Management.Data.Context.Mappings
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasIndex(e => e.ItemId, "IX_OrderItems_ItemsId");

            builder.HasIndex(e => e.OrderId, "IX_OrderItems_OrderId");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");

            builder.HasOne(d => d.Item).WithMany(p => p.OrderItems).HasForeignKey(d => d.ItemId).HasConstraintName("FK__OrderItem__ItemI__412EB0B6");

            builder.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasForeignKey(d => d.OrderId).HasConstraintName("FK__OrderItem__Order__403A8C7D");
        }
    }
}