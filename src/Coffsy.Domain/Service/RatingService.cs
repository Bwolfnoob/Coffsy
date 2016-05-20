using Coffsy.Domain.Entities;
using Coffsy.Domain.Interface.Repository;
using Coffsy.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Domain.Service
{
    public class RatingService : BaseService<Rating>, IRatingService
    {
        private readonly IRatingRepository repository;

        public RatingService(IRatingRepository _repository)
            : base(_repository)
        {
            repository = _repository;
        }

        public override Rating GetById(int id)
        {
            return repository.GetBy(c => c.Id == id).Single();
        }
    }
}
