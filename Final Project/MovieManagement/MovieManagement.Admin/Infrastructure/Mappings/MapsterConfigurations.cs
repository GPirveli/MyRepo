using Mapster;
using Microsoft.Extensions.DependencyInjection;
using MovieManagement.Admin.Models;
using MovieManagement.Admin.Models.Requests;
using MovieManagement.Domain;
using MovieManagement.Domain.POCO;
using MovieManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Admin.Infrastructure.Mappings
{
    public static class MapsterConfigurations
    {
        public static void RegisterMaps(this IServiceCollection service)
        {
            TypeAdapterConfig<Movie, MovieServiceModel>.NewConfig().TwoWays();
            TypeAdapterConfig<SoldTicketServiceModel, SoldTicket>.NewConfig();
            TypeAdapterConfig<BookedTicketServiceModel, BookedTicket>.NewConfig();
            TypeAdapterConfig<BookedTicket, SoldTicketServiceModel>.NewConfig();
            TypeAdapterConfig<SessionServiceModel, Session>.NewConfig().TwoWays();
            TypeAdapterConfig<BookedTicketServiceModel, BookedTicket>.NewConfig().TwoWays();
            TypeAdapterConfig<Account, AccountServiceModel>.NewConfig().TwoWays();
            TypeAdapterConfig<AccountServiceModel, AccountViewModel>.NewConfig();
            TypeAdapterConfig<LogInViewModel, AccountServiceModel>.NewConfig();
            TypeAdapterConfig<LogInAccountServiceModel, Account>.NewConfig();
            TypeAdapterConfig<MovieServiceModel, MovieViewModel>.NewConfig();
            TypeAdapterConfig<CreateMovieRequest, MovieServiceModel>.NewConfig();
            TypeAdapterConfig<Movie, EditMovieRequest>.NewConfig();
            TypeAdapterConfig<EditMovieRequest, MovieServiceModel>.NewConfig();
            TypeAdapterConfig<BookedTicketServiceModel, BookedTicketViewModel>.NewConfig();
        }
    }
}
