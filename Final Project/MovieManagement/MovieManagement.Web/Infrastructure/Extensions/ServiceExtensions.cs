using Microsoft.Extensions.DependencyInjection;
using MovieManagement.Service.Abstractions;
using MovieManagement.Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Web.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookTicketsService, BookTicketsService>();
            services.AddScoped<ISoldTicketService, SoldTicketService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IJWTService, JWTService>();
        }
    }
}
