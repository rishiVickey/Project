using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entity;
using Core.Interface;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class productsController : ControllerBase
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
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await _productsRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<product>, IReadOnlyList<ProductToReturnDto>>(products));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _productsRepo.GetEntityWithSpec(spec);

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