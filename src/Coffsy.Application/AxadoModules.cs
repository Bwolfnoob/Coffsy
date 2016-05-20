using AutoMapper;
using Coffsy.Application.Entity;
using Coffsy.Application.Interfaces;
using Coffsy.Domain.Interface.Repository;
using Coffsy.Domain.Interface.Services;
using Coffsy.Domain.Service;
using Coffsy.Infraestrucure.Repositories;
using Coffsy.vPet.Infraestructure.data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Coffsy.Application
{
    public class AxadoModules
    {
        public static void SetAppService(IServiceCollection services)
        {

            Mapper.Initialize(c => { c.CreateMissingTypeMaps = true; });

            services.AddTransient<CoffsyContext>();

            services.AddTransient<ICarrierRepository, CarrierRepository>();
            services.AddTransient<ICarrierService, CarrierService>();
            services.AddTransient<ICarrierAppService, CarrierAppService>();

            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<IRatingService, RatingService>();
            services.AddTransient<IRatingAppService, RatingAppService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserAppService, UserAppService>();

           
        }
    }
}
