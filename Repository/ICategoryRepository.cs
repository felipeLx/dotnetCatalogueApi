using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using aspNetEssencial.Models;

namespace aspNetEssencial.Repository
{
    public interface ICategoryRepository: IRepository<Category>
    {
        IEnumerable<Category> GetCategoryProducts();
    }
}