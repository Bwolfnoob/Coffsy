using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Domain.Entities
{
    public abstract class Entity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public bool Ativo { get; set; }
    }
}
