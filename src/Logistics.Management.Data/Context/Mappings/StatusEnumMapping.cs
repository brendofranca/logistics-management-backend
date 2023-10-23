using Logistics.Management.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logistics.Management.Data.Context.Mappings
{
    public class StatusEnumMapping : IEntityTypeConfiguration<StatusEnum>
    {
        public void Configure(EntityTypeBuilder<StatusEnum> builder)
        {
            builder.ToTable("StatusEnum");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.StatusName).HasMaxLength(255);
        }
    }
}