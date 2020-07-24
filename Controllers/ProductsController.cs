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
    public class ProductsController : ControllerBase
    {
        private IUOWork _uof;
        public ProductsController(IUOWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _uof.ProductRepository.Get().ToList();
        }

        [HttpGet("{id}", Name="GetProduct")]
        public ActionResult<Product> Get(int id)
        {
            var product = _uof.ProductRepository.GetById(p => p.ProductId == id);
            if(product == null) 
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Product product)
        {
            _uof.ProductRepository.Add(product);
            _uof.Commit();
            
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

            _uof.ProductRepository.Update(product);
            _uof.Commit();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            var product = _uof.ProductRepository.GetById(p => p.ProductId == id);

            if(product == null)
            {
                return NotFound();
            }

            _uof.ProductRepository.Delete(product);
            _uof.Commit();
            return product;
        }

        [HttpGet("lessprice")]
        public ActionResult<IEnumerable<Product>> GetProductByPrice()
        {
            return _uof.ProductRepository.GetProductByPrice().ToList();
        }
    }
}
