using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.EntityMetaModel;

namespace CoreDal.Repository 
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        
        List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);
     
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
     
        TEntity GetById(object id);
     
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
     
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate = null);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
     
        void Edit(TEntity entity);
     
        void Delete(object id);
    }
}