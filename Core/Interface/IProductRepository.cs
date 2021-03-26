using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Interface
{
    public interface IProductRepository
    {
        Task<product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<product>> GetProductsAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

    }
}