using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Service.Abstractions;
using PersonManagement.Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Web.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IActivityService, ActivityService>();
        }
    }
}
