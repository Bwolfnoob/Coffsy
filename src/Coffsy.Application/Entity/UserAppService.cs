using AutoMapper;
using Coffsy.Application.Interfaces;
using Coffsy.Application.ViewModels;
using Coffsy.Domain.Entities;
using Coffsy.Domain.Interface.Services;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coffsy.Application.Entity
{
    public class UserAppService : BaseAppService<User>, IUserAppService
    {
        private readonly IUserService service;

        public UserAppService(IUserService _service)
            : base(_service)
        {
            service = _service;
        }

        public UserViewModel Login(LoginViewModel usuario)
        {
            return Mapper.Map<UserViewModel>(service.LoginVerify(usuario.Name, usuario.Password));
        }

        public override Result<IEnumerable<SelectListItem>> GetSelectList()
        {
            try
            {
                return Result.Ok(service.GetAll().Where(c => c.Active).Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }));
            }
            catch (Exception e)
            {
                return Result.Fail<IEnumerable<SelectListItem>>(e.Message);
            }
        }
    }
}
