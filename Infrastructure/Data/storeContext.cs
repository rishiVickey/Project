
using System.Linq;
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
        
            if(Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite"){
                
                foreach(var entityType in modelBuilder.Model.GetEntityTypes()){
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach(var property in properties){
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
        }
    }
}