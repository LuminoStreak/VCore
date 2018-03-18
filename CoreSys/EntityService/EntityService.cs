using CoreDal;
using Core.EntityMetaModel;
using System;
using System.Collections.Generic;
using CoreDal.Repository;

namespace Core.Service
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
       IRepositoryUnit _repositoryUnit;
       IRepository<T> _repository;
 
       public EntityService(IRepositoryUnit unitOfWork, IRepository<T> repository)
       {
           _repositoryUnit = unitOfWork;
           _repository = repository;
       }     
 
 
       public virtual void Create(T entity)
       {
           if (entity == null)
           {
               throw new ArgumentNullException("entity");
           }
           _repository.Add(entity);
           _repositoryUnit.Save();         
       }
 
 
       public virtual void Update(T entity)
       {
           if (entity == null) throw new ArgumentNullException(nameof(entity));
           _repository.Edit(entity);
           _repositoryUnit.Save();
       }
 
       public virtual void Delete(T entity)
       {
           if (entity == null) throw new ArgumentNullException(nameof(entity));
           _repository.Delete(entity);
           _repositoryUnit.Save();
       }
 
       public virtual IEnumerable<T> GetAll()
       {
           return _repository.GetAll();
       }
   }
}