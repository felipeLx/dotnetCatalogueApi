using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using aspNetEssencial.Context;
using aspNetEssencial.Repository;

namespace aspNetEssencial.Repository
{
    public class UOWork : IUOWork
    {
        private ProductRepository _productRepo;
        private CategoryRepository _categoryRepo;
        public AppDbContext _context;

        public UOWork(AppDbContext context)
        {
            _context = context;
        }
        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepo = _productRepo ?? new ProductRepository(_context);
            }
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepo = _categoryRepo ?? new CategoryRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}