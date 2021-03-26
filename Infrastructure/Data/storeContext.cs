
using System.Reflection;
using Core.Entity;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class storeContext : DbContext
    {
        public storeContext(DbContextOptions<storeContext> options) : base(options)
        {

        }

        public DbSet<product> products {get; set;}
        public DbSet<ProductBrand> ProductBrands { get; set;}
        public DbSet<ProductType> productTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}