using Golden_Leaf_Back_End.Models.AccountModels;
using Golden_Leaf_Back_End.Models.CategoryModels;
using Golden_Leaf_Back_End.Models.ClerkModels;
using Golden_Leaf_Back_End.Models.ClientModels;
using Golden_Leaf_Back_End.Models.OrderModels;
using Golden_Leaf_Back_End.Models.PaymentModels;
using Golden_Leaf_Back_End.Models.ProductModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Golden_Leaf_Back_End.Models
{
    public class GoldenLeafContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }        
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public GoldenLeafContext(DbContextOptions<GoldenLeafContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
           
        }
    }
}
