using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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
              .HasOne(o => o.Clerk)
              .WithMany(c => c.Orders)
              .HasForeignKey("ClerkId");

            builder
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId);
                

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
