using AcmePortal.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmePortal.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        DbTransactionResult Create(T entity);
        Task<DbTransactionResult> CreateAsync(T entity);
    }
}
