using Mapster;
using Microsoft.Extensions.DependencyInjection;
using MovieManagement.Domain;
using MovieManagement.Domain.POCO;
using MovieManagement.Service.Models;
using MovieManagement.Web.Models;
using MovieManagement.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Web.Infrastructure.Mapping
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection service)
        {
            //TypeAdapterConfig<PersonServiceModel, PersonDTO>
            //.NewConfig()
            //.TwoWays();

            TypeAdapterConfig<Movie, MovieServiceModel>.NewConfig();
            TypeAdapterConfig<SoldTicketServiceModel, SoldTicket>.NewConfig();
            TypeAdapterConfig<BookedTicketServiceModel, BookedTicket>.NewConfig();
            TypeAdapterConfig<BookedTicket, SoldTicketServiceModel>.NewConfig();
            TypeAdapterConfig<SessionServiceModel, Session>.NewConfig().TwoWays();
            TypeAdapterConfig<SessionServiceModel, SessionDTO>.NewConfig();
            TypeAdapterConfig<BookedTicketServiceModel, BookedTicket>.NewConfig();
            TypeAdapterConfig<BookTicketsRequest, BookedTicketServiceModel>.NewConfig();
            TypeAdapterConfig<RegisterUserRequest, AccountServiceModel>.NewConfig();
            TypeAdapterConfig<AccountServiceModel, Account>.NewConfig().Ignore(x => x.Id);
            TypeAdapterConfig<MovieServiceModel, MovieDTO>.NewConfig();
            TypeAdapterConfig<SellTicketsRequest, SoldTicketServiceModel>.NewConfig().Ignore(x => x.Id);

        }
    }
}
