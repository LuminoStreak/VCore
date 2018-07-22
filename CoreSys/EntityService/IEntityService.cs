using System.Collections.Generic;
using Core.EntityMetaModel;

namespace Core.Service
{
    public interface IEntityService<T> : IService 
    {
        // void Create<T>(T entity) where T : BaseEntity;
        // void Delete<T>(T entity) where T : BaseEntity;
        // IEnumerable<T> GetAll<T>() where T : BaseEntity;      
        // void Update<T>(T entity)where T : BaseEntity;
    }
}