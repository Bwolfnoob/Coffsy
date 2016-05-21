using Coffsy.Domain.Entities;
using Coffsy.Domain.Interface.Repository;
using Coffsy.vPet.Infraestructure.data.Context;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Infraestrucure.Repositories
{
    public class CarrierRepository : BaseRepository<Carrier>, ICarrierRepository
    {
        public CarrierRepository(CoffsyContext context) : base(context)
        {
        }
        public override IEnumerable<Carrier> GetAll()
        {
            return DbSet.Include(e => e.Address).AsNoTracking();

        }

        public Carrier GetById(int id)
        {
            return DbSet.Include(e => e.Address).ThenInclude(c=>c.Carrier).Where(c=>c.Id == id).FirstOrDefault();
        }
    }
}
