using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Core.EntityMetaModel;
using System.Linq;

namespace CoreDal.Repository 
{
    public sealed class RepositoryUnit: IRepositoryUnit
    {
        private DbContext _dbContext;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        
        public RepositoryUnit(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {            
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            IRepository<TEntity> repository = new Repository<TEntity>(_dbContext);
            repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        void IRepositoryUnit.Save()
        {
            _dbContext.SaveChanges();
        }

        public T GetRepository<T>() where T : class
        {
            // using (var kernel = new StandardKernel())
            // {
            //     kernel.Load(Assembly.GetExecutingAssembly());
            //     var result = kernel.Get<T>(new Argument("context", _context));
            //     // Requirements
            //     //   - Must be in this assembly
            //     //   - Must implement a specific interface (i.e. IBlogModule)
            //     if (result != null && result.GetType().GetInterfaces().Contains(typeof(IBlogModule)))
            //     {
            //         return result;
            //     }
            // }
            // Optional: return an error instead of a null?
            //var msg = typeof (T).FullName + " doesn't implement the IBlogModule.";
            //throw new Exception(msg);
            return null;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {                    
                    if (_dbContext != null)
                    {
                        _dbContext.Dispose();
                        _dbContext = null;
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~RepositoryUnit() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void System.IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}