using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Coffsy.Application.ViewModels;
using Coffsy.Application.Entity;
using Coffsy.Application.Interfaces;
using Coffsy.Presentation.Exceptions;
using System.Net;

namespace Coffsy.Presentation.Controllers
{
    public class UserController : Controller
    {
        private IUserAppService service;

        public UserController(IUserAppService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrUpdate([FromForm] UserViewModel User)
        {
            Result result;

            if (User.Id > 0)
            {
                result = service.Update(User);
            }
            else
            {
                result = service.Add(User);
            }

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new HttpException(HttpStatusCode.BadRequest, result.Error);
            }
        }

        public IActionResult Add()
        {
            return View("_form", new UserViewModel());
        }

        public IActionResult Edit(int id)
        {
            return View("_form", service.GetById<UserViewModel>(id).Value);
        }

        public IActionResult Delete(int id)
        {
            var result = service.Remove<UserViewModel>(id);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new HttpException(HttpStatusCode.BadRequest, result.Error);
            }
        }

        public JsonResult Load(DTParameters param)
        {
            try
            {
                var registers = service.GetAll<UserViewModel>(param.Start,
                    param.Length,
                    param.SortOrder,
                    param.Search.Value).Value
                    .ToList();

                var returnResult = new
                {
                    recordsTotal = service.Count().Value,
                    recordsFiltered = service.Count().Value,
                    data = from c in registers
                           select new
                           {
                               c.Name,
                               c.Email,
                               btn = string.Format("<a class='btn btn-sm btn-primary' style='margin-right: 5px' href='/User/Edit/{0}' title='Editar'><i class='glyphicon glyphicon-pencil' style='margin-right: 5px'></i>Editar</a><a class='btn btn-sm btn-danger' href='/User/Delete/{0}' title='Remover'><i class='glyphicon glyphicon-trash' style='margin-right: 5px'></i>Remover</a>", c.Id)
                           }
                };

                return Json(returnResult);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }
    }
}
