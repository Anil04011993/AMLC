using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Abstraction.Reposotory
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }

}
