using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Golden_Leaf_Back_End.Models.PaymentModels
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {

            builder
                .HasOne(p => p.Client)
                .WithMany(c => c.Payments)
                .HasForeignKey("ClientId");

            builder
               .HasOne(p => p.Clerk)
               .WithMany(c => c.Payments)
               .HasForeignKey("ApplicationUserId");


            builder.Property(p => p.Date)                
               .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
