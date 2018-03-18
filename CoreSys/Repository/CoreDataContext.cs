using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;  
using Core.EntityMetaModel;

namespace CoreSys.Data
{  
    public partial class CoreDataContext: DbContext  
    {  
        public CoreDataContext(DbContextOptions<CoreDataContext> options) : base(options)  
        {  
            
        }  
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
            base.OnModelCreating(modelBuilder);  
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