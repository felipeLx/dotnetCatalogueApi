using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using aspNetEssencial.Models;

namespace aspNetEssencial.Repository
{
    public interface IProductRepository: IRepository<Product>
    {
        IEnumerable<Product> GetProductByPrice();
    }
}