using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Core.EntityMetaModel;

namespace CoreDal.Repository
{
    public abstract class AbstractRepository<TEntity> :DbContext, IRepository
    {        
        // private DbSet<TEntity> _dbSet;
    
        public AbstractRepository()
        {            
            // this._dbSet = context.Set<TEntity>();
        }

         public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                  && (x.State == EntityState.Added || x.State == EntityState.Modified));
 
            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {                    
                    DateTime now = DateTime.UtcNow;
 
                    if (entry.State == EntityState.Added)
                    {                
                        entity.CreatedDate = now;
                    }
                    else 
                    {                      
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;                   
                    }
 
                    entity.UpdatedDate = now;
                }
            }
            return base.SaveChanges();
        }

    }
}