using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Golden_Leaf_Back_End.Models.ClerkModels
{
    public class ClerkConfiguration : IEntityTypeConfiguration<Clerk>
    {
        public void Configure(EntityTypeBuilder<Clerk> builder)
        {
            builder.Property<string>("UserId");            
        }
    }
}
