using Mapster;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Domain.POCO;
using PersonManagement.Service.Models;
using PersonManagement.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Web.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection service)
        {
            TypeAdapterConfig<PersonServiceModel, Person>.NewConfig().TwoWays();
            TypeAdapterConfig<CreatePersonRequest, PersonServiceModel>.NewConfig();
            TypeAdapterConfig<UpdatePersonRequest, PersonServiceModel>.NewConfig();
        }
    }
}
