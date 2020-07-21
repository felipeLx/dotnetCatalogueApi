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
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name="GetCategory")]
        public ActionResult<Category> Get(int id)
        {
            var category = _context.Categories.AsNoTracking()
                .FirstOrDefault(p => p.CategoryId == id);
            if(category == null) 
            {
                return NotFound();
            }
            return category;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            
            return new CreatedAtRouteResult("GetCategory",
                new { id= category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Category category)
        {
            if(id != category.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

            if(category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return _context.Categories.Include(cat => cat.Products).ToList();
        }
    }
}
