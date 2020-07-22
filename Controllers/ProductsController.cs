using aspNetEssencial.Context;
using aspNetEssencial.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace aspNetEssencial.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}", Name="GetProduct")]
        public async Task<ActionResult<Product>> GetAsync(int id)
        {
            var product = await _context.Products.AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);
            if(product == null) 
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            
            return new CreatedAtRouteResult("GetProduct",
                new { id= product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Product product)
        {
            if(id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

            if(product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }
    }
}
