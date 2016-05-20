using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Application.Interfaces
{
    public interface IBaseAppService<TEntity> where TEntity : class
    {
        void Add<TViewModel>(TViewModel obj);
        IEnumerable<TViewModel> GetAll<TViewModel>(int? skip = null, int? take = null, string sort = null, string search = null) where TViewModel : class;
        TViewModel GetById<TViewModel>(int id);
        int Count();
        void Update<TViewModel>(TViewModel obj);
        void Remove<TViewModel>(int id);
        void Dispose();
    }
}
