using Coffsy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Domain.Interface.Services
{
    public interface IUserService : IBaseService<User>
    {
        User LoginVerify(string _name, string _password);
    }
}
