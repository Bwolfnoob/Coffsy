using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Domain.Interface.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
