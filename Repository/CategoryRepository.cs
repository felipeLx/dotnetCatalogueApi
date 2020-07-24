using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using aspNetEssencial.Models;
using aspNetEssencial.Context;

namespace aspNetEssencial.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
        public IEnumerable<Category> GetCategoryProducts()
        {
            return Get().Include(c => c.Products);
        }
    }
}