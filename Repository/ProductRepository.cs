using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using aspNetEssencial.Models;
using aspNetEssencial.Context;

namespace aspNetEssencial.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
        public IEnumerable<Product> GetProductByPrice()
        {
            return Get().OrderBy(c => c.Price).ToList();
        }
    }
}