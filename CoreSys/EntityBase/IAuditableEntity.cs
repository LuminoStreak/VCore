using System;

namespace Core.EntityMetaModel
{
    public interface IAuditableEntity 
    {
       DateTime CreatedDate { get; set; }
     
       Int64 CreatedById { get; set; }
 
       DateTime UpdatedDate { get; set; }
             
       Int64 UpdatedById { get; set; }
    }
}