using Coffsy.Application.Interfaces;
using Coffsy.Domain.Entities;
using Coffsy.Domain.Interface.Services;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Application.Entity
{
    public class RatingAppService : BaseAppService<Rating>, IRatingAppService
    {
        private readonly IRatingService service;

        public RatingAppService(IRatingService _service)
            : base(_service)
        {
            service = _service;
        }
       
    }
}
