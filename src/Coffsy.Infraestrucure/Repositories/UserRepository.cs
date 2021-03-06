﻿using Coffsy.Domain.Entities;
using Coffsy.Domain.Interface.Repository;
using Coffsy.vPet.Infraestructure.data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Infraestrucure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CoffsyContext context) : base(context)
        {
        }
    }
}
