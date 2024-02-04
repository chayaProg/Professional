using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Services.Intaefaces;
using Repository;
using Repository.Repositories;
using Common.Entity;
using Services.ServicesF;

namespace Services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepository();
            /*            service.AddScoped<IService<AreaDto>,
            */
            services.AddScoped<IService<AreaDto>, AreaService>();
            services.AddScoped<IService<CategoryDto>, CategoryService>();
            services.AddScoped<IService<ProfessionalDto>, ProfessionalService>();
            services.AddScoped<IService<ResponseDto>, ResponseService>();
            services.AddScoped<IService<UserDto>, UserService>();
            services.AddScoped<IService<ProfessionalDescriptionDto>,ProfessionalDesService>();
            services.AddAutoMapper(typeof(MapperProfile));
            return services;
        }
    }
}
