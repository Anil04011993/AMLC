using AMLRS.Core.Abstraction.Reposotory;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AmlDbContext _context;

        public UnitOfWork(AmlDbContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }

}
