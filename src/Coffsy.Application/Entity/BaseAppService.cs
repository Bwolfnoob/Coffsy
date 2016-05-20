using AutoMapper;
using Coffsy.Application.Interfaces;
using Coffsy.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coffsy.Application.Extensions;

namespace Coffsy.Application.Entity
{
   public class BaseAppService<TEntity> : IBaseAppService<TEntity> where TEntity : class
    {
        private readonly IBaseService<TEntity> service;

        public BaseAppService(IBaseService<TEntity> _service)
        {
            service = _service;
        }

        public void Add<TViewModel>(TViewModel obj)
        {            
            service.Add(Mapper.Map<TViewModel, TEntity>(obj));
        }

        public void Update<TViewModel>(TViewModel obj)
        {
            service.Update(Mapper.Map<TViewModel, TEntity>(obj));
        }

        public void Remove<TViewModel>(int id)
        {
            service.Remove(service.GetById(id));
        }

        public void Dispose()
        {
            service.Dispose();
        }

        public int Count()
        {
            return service.GetAll().Count();
        }

        public IEnumerable<TViewModel> GetAll<TViewModel>(int? skip = null, int? take = null, string sort = null, string search = null) where TViewModel : class
        {
            var query = service.GetAll();

            string property, orderBy;

            if (!string.IsNullOrEmpty(sort))
            {
                property = sort.SplitSpace(0);
                orderBy = sort.SplitSpace(1);

                if (string.IsNullOrEmpty(orderBy))
                {
                    query = query.OrderBy(i => i.GetPropertyFromString(property));
                }
                else
                {
                    query = query.OrderByDescending(i => i.GetPropertyFromString(property));
                }
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }          

            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TViewModel>>(query);
        }

        public TViewModel GetById<TViewModel>(int id)
        {
            try
            {
                return Mapper.Map<TEntity, TViewModel>(service.GetById(id));
            }
            catch
            {
                throw new Exception("Registro não localizado, verifique se o mesmo não foi excluído");
            }
        }
    }
}
