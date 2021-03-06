using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entity;
using Core.Interface;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class productsController : BaseApiController
    {

        private readonly IGenericRepository<product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productsBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        private readonly IMapper _mapper;

        public productsController(IGenericRepository<product> productsRepo,
        IGenericRepository<ProductBrand> productsBrandRepo, IGenericRepository<ProductType> productTypeRepo,
        IMapper Mapper)
        {
            _mapper = Mapper;

            _productTypeRepo = productTypeRepo;
            _productsBrandRepo = productsBrandRepo;
            _productsRepo = productsRepo;


        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
            [FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

        
             var CountSpec = new ProductWithFilterForCountSpecification(productParams); 

             var totalItems = await _productsRepo.CountAsync(CountSpec);
             
             var products = await _productsRepo.ListAsync(spec);

             var data = _mapper.Map<IReadOnlyList<product>, IReadOnlyList<ProductToReturnDto>>(products);

            
            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex,productParams.PageSize,
            totalItems,data));

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _productsRepo.GetEntityWithSpec(spec);
             if(product == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductsBrands()
        {
            return Ok(await _productsBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsType()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }

    }
}