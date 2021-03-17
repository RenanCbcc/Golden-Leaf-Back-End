using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Models.OrderModels
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
               .HasOne(o => o.Client)
               .WithMany(c => c.Orders)
               .HasForeignKey("ClientId");

            builder
                .HasMany(o => o.Items)
                .WithOne(i => i.Order);

            builder.Property(c => c.Status).HasMaxLength(20)
                                           .IsRequired()
                                           .HasConversion<string>(
                e => e.ToString(),
                e => (Status)Enum.Parse(typeof(Status), e)
                );

            builder.Property(o => o.Date)
               .HasColumnType("datetime")
               .HasDefaultValueSql("getdate()");
        }
    }
}
