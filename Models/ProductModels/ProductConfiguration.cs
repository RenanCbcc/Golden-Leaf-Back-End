using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Models.ProductModels
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Code).HasMaxLength(13).IsRequired();
            builder.HasAlternateKey(p => p.Code);

            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey("CategoryId");
            
        }
    }
}
