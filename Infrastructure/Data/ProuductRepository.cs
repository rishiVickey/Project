using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProuductRepository : IProductRepository
    {
        private readonly storeContext _context;

        public ProuductRepository(storeContext context)
        {
            _context = context;
        }

        public async Task<product> GetProductByIdAsync(int id)
        {
            return await _context.products.
                Include(p => p.ProductType).
                Include(p => p.ProductBrand).
                FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<product>> GetProductsAsync()
        {
            return await _context.products.
                Include(p => p.ProductType)
                .Include(P => P.ProductBrand).
                ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.productTypes.ToListAsync();
        }
    }
}