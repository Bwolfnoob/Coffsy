using Coffsy.Application.Interfaces;
using Coffsy.Domain.Entities;
using Coffsy.Domain.Interface.Services;

namespace Coffsy.Application.Entity
{
    public class RateAppService : BaseAppService<Rate>, IRateAppService
    {
        private readonly IRateService service;

        public RateAppService(IRateService _service)
            : base(_service)
        {
            service = _service;
        }
       
    }
}
