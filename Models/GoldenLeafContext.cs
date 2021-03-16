using Golden_Leaf_Back_End.Models.CategoryModels;
using Golden_Leaf_Back_End.Models.ClientModels;
using Golden_Leaf_Back_End.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace Golden_Leaf_Back_End.Models
{
    public class GoldenLeafContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }

        public GoldenLeafContext(DbContextOptions<GoldenLeafContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());

        }
    }
}
