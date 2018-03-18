using System;

namespace Core.EntityMetaModel
{
    public abstract class AuditableEntity : BaseEntity, IAuditableEntity
    {       
        public DateTime CreatedDate { get; set; }
     
        public Int64 CreatedById { get; set; }
        
        public DateTime UpdatedDate { get; set; }       
       
        public Int64 UpdatedById { get; set; }
    }    
}