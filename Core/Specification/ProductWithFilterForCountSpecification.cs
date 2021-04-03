using Core.Entity;

namespace Core.Specification
{
    public class ProductWithFilterForCountSpecification :BaseSpecification<product>
    {
        public ProductWithFilterForCountSpecification(ProductSpecParams productparams)
         : base(x => 
            (string.IsNullOrEmpty(productparams.Search) || x.Name.ToLower().Contains(productparams.Search))&&
            (!productparams.BrandId.HasValue || x.ProductBrandId == productparams.BrandId) && 
            (!productparams.TypeId.HasValue || x.ProductTypeId == productparams.TypeId)
         )
        {
        }
    }
}