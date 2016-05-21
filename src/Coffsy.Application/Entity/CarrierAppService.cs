using Coffsy.Application.Interfaces;
using Coffsy.Domain.Entities;
using Coffsy.Domain.Interface.Services;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coffsy.Application.Entity
{
    public class CarrierAppService : BaseAppService<Carrier>, ICarrierAppService
    {
        private readonly ICarrierService service;

        public CarrierAppService(ICarrierService _service)
            : base(_service)
        {
            service = _service;
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
