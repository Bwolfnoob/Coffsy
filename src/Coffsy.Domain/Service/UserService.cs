using Coffsy.Domain.Entities;
using Coffsy.Domain.Interface.Repository;
using Coffsy.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Domain.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository _repository)
            : base(_repository)
        {
            repository = _repository;
        }

        public User LoginVerify(string _name, string _password)
        {
            User user;
            try
            {
              user = repository.GetAll().Single(u => u.IsLoggable(_name , _password));
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Login incorreto ou usuário não está ativo!");
            }

            return user;
        }

        public override User GetById(int id)
        {
            return repository.GetBy(c => c.Id == id).Single();
        }
    }
}
