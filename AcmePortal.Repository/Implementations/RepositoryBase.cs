using AcmePortal.Repository.Interfaces;
using AcmePortal.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmePortal.Repository.Implementations
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AcmeContext _acmeContext { get; set; }
        public RepositoryBase(AcmeContext acmeContext)
        {
            _acmeContext = acmeContext;
        }
        public IQueryable<T> FindAll()
        {
            return _acmeContext.Set<T>().AsNoTracking();
        }

        public DbTransactionResult Create(T entity)
        {
            _acmeContext.Set<T>().Add(entity);
            return SaveChanges(entity);
        }

        public async Task<DbTransactionResult> CreateAsync(T entity)
        {
            this._acmeContext.Set<T>().Add(entity);
            return await SaveChangesAsync(entity);
        }

        private DbTransactionResult SaveChanges(T entity)
        {
            try
            {
                this._acmeContext.SaveChanges();

                DbTransactionResult result = new DbTransactionResult
                {
                    Entity = entity
                };
                return result;

            }
            catch (InvalidOperationException e)
            {
                return new DbTransactionResult(e.Message);

            }
            catch (DbUpdateException e)
            {
                Exception ex = e;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                return new DbTransactionResult(ex.Message);

            }
            catch (Exception e)
            {
                return new DbTransactionResult(e.Message);
            }
        }
        private async Task<DbTransactionResult> SaveChangesAsync(T entity)
        {
            try
            {
                await this._acmeContext.SaveChangesAsync();

                DbTransactionResult result = new DbTransactionResult
                {
                    Entity = entity
                };
                return result;

            }
            catch (InvalidOperationException e)
            {
                return new DbTransactionResult(e.Message);

            }
            catch (DbUpdateException e)
            {
                Exception ex = e;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                return new DbTransactionResult(ex.Message);

            }
            catch (Exception e)
            {
                return new DbTransactionResult(e.Message);
            }
        }
    }
}