using Coffsy.Domain.Entities;
using Coffsy.Domain.Interface.Repository;
using Coffsy.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Domain.Service
{
    public class RateService : BaseService<Rate>, IRateService
    {
        private readonly IRateRepository repository;

        public RateService(IRateRepository _repository)
            : base(_repository)
        {
            repository = _repository;
        }

        public override Rate GetById(int id)
        {
            return repository.GetBy(c => c.Id == id).Single();
        }
    }
}
