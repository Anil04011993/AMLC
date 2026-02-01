using AMLRS.Core.Domains.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AMLRS.Core.Abstraction.Reposotory
{
    /*
    IRepository<EntityProfile>
    IRepository<Case>
    IRepository<Transaction>
    IRepository<Document>
    IRepository<KycCheck>
    IRepository<SarStrReport>
    */
    public interface IRepository<T, TKey> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(TKey id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }


}
