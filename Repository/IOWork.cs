using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspNetEssencial.Repository
{
    public interface IUOWork
    {
        IProductRepository ProductRepository { get;}
        ICategoryRepository CategoryRepository { get;}
        void Commit();
        
    }
}