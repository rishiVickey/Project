using System;
using System.Linq.Expressions;
using Core.Entity;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productparams)
         : base(x => 
            (string.IsNullOrEmpty(productparams.Search) || x.Name.ToLower().Contains(productparams.Search))&&
            (!productparams.BrandId.HasValue || x.ProductBrandId == productparams.BrandId) && 
            (!productparams.TypeId.HasValue || x.ProductTypeId == productparams.TypeId)
         )
        {
            AddInclude(X => X.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productparams.PageSize * (productparams.PageIndex - 1),productparams.PageSize);
            
            if(!string.IsNullOrEmpty(productparams.Sort)){
                switch(productparams.Sort)
                {
                    case "PriceAsc":
                       AddOrderBy(p => p.Price);
                       break;
                    case "priceDesc":
                       AddOrderByDescending(p => p.Price);
                       break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
             AddInclude(X => X.ProductType);
             AddInclude(x => x.ProductBrand);
        }
    }
}