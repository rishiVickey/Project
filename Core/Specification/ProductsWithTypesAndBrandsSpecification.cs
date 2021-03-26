using System;
using System.Linq.Expressions;
using Core.Entity;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(X => X.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
             AddInclude(X => X.ProductType);
             AddInclude(x => x.ProductBrand);
        }
    }
}