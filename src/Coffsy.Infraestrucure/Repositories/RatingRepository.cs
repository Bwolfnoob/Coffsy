using Coffsy.Domain.Entities;
using Coffsy.Domain.Interface.Repository;
using Coffsy.vPet.Infraestructure.data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Infraestrucure.Repositories
{
    public class RateRepository : BaseRepository<Rate>, IRateRepository
    {
        public RateRepository(CoffsyContext context) : base(context)
        {
        }
    }
}
