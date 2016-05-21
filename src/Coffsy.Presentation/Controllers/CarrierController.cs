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
    public class CarrierController : Controller
    {
        private ICarrierAppService service;

        public CarrierController(ICarrierAppService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrUpdate([FromForm] CarrierViewModel Carrier)
        {
            Result result;

            if (Carrier.Id > 0)
            {
                result = service.Update(Carrier);
            }
            else
            {
                result = service.Add(Carrier);
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
            var carrier = new CarrierViewModel() { Address = new AddressViewModel() };
      
            return View("_form", carrier);
        }

        public IActionResult Edit(int id)
        {
            return View("_form", service.GetById<CarrierViewModel>(id).Value);
        }

        public IActionResult Delete(int id)
        {
            var result = service.Remove<CarrierViewModel>(id);

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
                var registers = service.GetAll<CarrierViewModel>(param.Start,
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
                               c.Phone,
                               TotalRatings = c.TotalRatings(),
                               btn = string.Format("<a class='btn btn-sm btn-primary' style='margin-right: 5px' href='/Carrier/Edit/{0}' title='Editar'><i class='glyphicon glyphicon-pencil' style='margin-right: 5px'></i>Editar</a><a class='btn btn-sm btn-danger' href='/Carrier/Delete/{0}' title='Remover'><i class='glyphicon glyphicon-trash' style='margin-right: 5px'></i>Remover</a>", c.Id)
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
