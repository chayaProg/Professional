using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Repository.Intarfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Area>,AreaRepository>();
            services.AddScoped<IRepository<Category>,CategoryRepository>();
            services.AddScoped<IRepository<Professional>,ProfessionalRepository>();
            services.AddScoped<IRepository<User>,UserRepository>();
            services.AddScoped<IRepository<Response>,ResponseRepository>();
            services.AddScoped<IRepository<ProfessionalDescription>,ProfessionalDesRepository>();

            return services;
        }
    }
}
