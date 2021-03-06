
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
    }
}