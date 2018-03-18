using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Core.EntityMetaModel;

namespace CoreDal.Repository
{
    public abstract class AbstractRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private DbContext context;
        private DbSet<TEntity> _dbSet;
    
        public AbstractRepository(DbContext context)
        {
            this.context = context;
            this._dbSet = context.Set<TEntity>();
        }
    
        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
    
            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);
    
            if (filter != null)
                query = query.Where(filter);
    
            if (orderBy != null)
                query = orderBy(query);
    
            return query.ToList();
        }
    
        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;
    
            if (filter != null)
                query = query.Where(filter);
    
            if (orderBy != null)
                query = orderBy(query);
    
            return query;
        }
    
        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }
    
        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
    
            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);
    
            return query.FirstOrDefault(filter);
        }

        public virtual IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate = null)
        { 
            if (predicate != null)
            {
                return _dbSet.Where(predicate);
            }

            return _dbSet.AsEnumerable<TEntity>();
        }
 
       public IEnumerable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
       { 
           IEnumerable<TEntity> query = _dbSet.Where(predicate).AsEnumerable(); 
           return query;
       }
        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }
    
        public virtual void Edit(TEntity entity)
        {
            _dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
    }

    public partial class Repository<TEntity> : AbstractRepository<TEntity> where TEntity : BaseEntity
    {
        public Repository(DbContext context) : base(context)
        {            

        }
    }
}