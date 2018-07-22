using CoreDal;
using Core.EntityMetaModel;
using System;
using System.Collections.Generic;
using CoreDal.Repository;

namespace Core.Service
{
    public class EntityService<T> : IEntityService<T>, IDisposable where T : IEntity
    {
       IRepository _repository;

       IEntityServiceExecutor _executor;
 
       public EntityService(IRepository repository)
       {     
            _repository = repository;
       }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {                    
                    if (_repository != null)
                    {
                        _repository.Dispose();
                        _repository = null;
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
 
    //    public virtual void Create(T entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException("entity");
    //        }
    //        _repository.Add(entity);
    //        _repositoryUnit.Save();         
    //    }
 
 
    //    public virtual void Update(T entity)
    //    {
    //        if (entity == null) throw new ArgumentNullException(nameof(entity));
    //        _repository.Edit(entity);
    //        _repositoryUnit.Save();
    //    }
 
    //    public virtual void Delete(T entity)
    //    {
    //        if (entity == null) throw new ArgumentNullException(nameof(entity));
    //        _repository.Delete(entity);
    //        _repositoryUnit.Save();
    //    }
 
    //    public virtual IEnumerable<T> GetAll()
    //    {
    //        return _repository.GetAll();
    //    }
   }
}