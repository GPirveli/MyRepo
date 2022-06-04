using Microsoft.Extensions.DependencyInjection;
using MovieManagement.Data;
using MovieManagement.Data.EF;
using MovieManagement.Data.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Admin.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookedTicketRepository, BookedTicketRepository>();
            services.AddScoped<ISoldTicketsRepository, SoldTicketRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
