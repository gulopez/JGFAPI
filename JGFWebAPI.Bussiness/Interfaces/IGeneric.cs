using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Bussiness.Interfaces
{
    public interface IGeneric<T>
    {
        ICollection<T> GetEntities();
        T GetEntity(Guid id);
        bool ExistsEntity(string keyword);
        bool ExistsEntity(Guid id);
        bool CreateEntity(T entity);
        bool UpdateEntity(T entity);
        bool DeleteEntity(T entity);
        bool Save();
    }
}
