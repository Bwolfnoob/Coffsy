using Coffsy.Application.Entity;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Application.Interfaces
{
    public interface IBaseAppService<TEntity> where TEntity : class
    {
        Result Add<TViewModel>(TViewModel obj);
        Result<IEnumerable<TViewModel>> GetAll<TViewModel>(int? skip = null, int? take = null, string sort = null, string search = null) where TViewModel : class;
        Result<TViewModel> GetById<TViewModel>(int id);
        Result<int> Count();
        Result Update<TViewModel>(TViewModel obj);
        Result Remove<TViewModel>(int id);
        Result<IEnumerable<SelectListItem>> GetSelectList();
    }
}
