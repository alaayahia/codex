using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Repository;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
           services.AddScoped<ICompensationsRepository, CompensationsRepository>();
           services.AddScoped<IEmployeesRepository, EmployeesRepository>();
           services.AddScoped<IEmpCompensationsRepository, EmpCompensationsRepository>();
           services.AddScoped<IEmpDocumentsRepository, EmpDocumentsRepository>();
           
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
        
    }
}