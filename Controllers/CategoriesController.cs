using aspNetEssencial.Repository;
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
        private readonly IUOWork _uof;
        public CategoriesController(IUOWork context)
        {
            _uof = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return _uof.CategoryRepository.Get().ToList();
        }

        [HttpGet("{id}", Name="GetCategory")]
        public ActionResult<Category> Get(int id)
        {
            var category = _uof.CategoryRepository.GetById(c => c.CategoryId == id);
            if(category == null) 
            {
                return NotFound();
            }
            return category;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Category category)
        {
            _uof.CategoryRepository.Add(category);
            _uof.Commit();
            
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

            _uof.CategoryRepository.Update(category);
            _uof.Commit();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> Delete(int id)
        {
            var category = _uof.CategoryRepository.GetById(c => c.CategoryId == id);

            if(category == null)
            {
                return NotFound();
            }

            _uof.CategoryRepository.Delete(category);
            _uof.Commit();
            return category;
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return _uof.CategoryRepository.GetCategoryProducts().ToList();
        }
    }
}
