using Coffsy.Application.ViewModels;
using Coffsy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Application.Interfaces
{
    public interface IUserAppService : IBaseAppService<User> , IDisposable
    {
        UserViewModel Login(LoginViewModel usuario);
    }
}
