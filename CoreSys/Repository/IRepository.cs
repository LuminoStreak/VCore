using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.EntityMetaModel;

namespace CoreDal.Repository 
{
    public interface IRepository: IDisposable
    {       
    //     List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
    //         params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity;
    //  
    //     IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null) where TEntity : IEntity;
    //  
    //     TEntity GetById(object id)  where TEntity : BaseEntity;
    //  
    //     TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity;
    //  
    //     IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate = null) where TEntity : BaseEntity;
    //     IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity;
    //     void Add(TEntity entity) where TEntity : BaseEntity;
    //  
    //     void Edit(TEntity entity) where TEntity : BaseEntity;
    //  
    //     void Delete(object id) where TEntity : BaseEntity;
    }
}