using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
[Route("api/[controller]")]
    public class productsController :ControllerBase
    {
        private readonly storeContext _context;
        public productsController(storeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<product>>> GetProducts(){
             var products =await _context.products.ToListAsync();
             return Ok(products);
        
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<product>> getProduct(int id){
            return await _context.products.FindAsync(id);
        }
        
    }
}