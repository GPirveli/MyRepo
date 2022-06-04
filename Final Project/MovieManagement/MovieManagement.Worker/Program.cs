using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieManagement.Data;
using MovieManagement.Data.EF;
using MovieManagement.Data.EF.Repository;
using MovieManagement.PersistanceDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration config = hostContext.Configuration;
                    //services.AddScoped<IServiceProvider, Worker>();
                    services.AddHostedService<Worker>();
                    services.AddScoped<ISessionRepository, SessionRepository>();
                    services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
                    services.AddDbContext<MovieManagementContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
                    //services.AddHostedService<Worker>();
                });
    }
}
