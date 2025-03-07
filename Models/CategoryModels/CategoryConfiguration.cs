﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Golden_Leaf_Back_End.Models.CategoryModels
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(50).IsRequired();
            builder.HasAlternateKey(c => c.Title);
        
        }
    }
}
