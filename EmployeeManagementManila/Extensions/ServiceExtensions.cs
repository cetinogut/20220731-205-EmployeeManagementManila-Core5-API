using Contracts;
using Entities;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementManila.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        // CORS(Cross-Origin Resource Sharing) is a mechanism that gives rights to the user to access resources from the server on a different domain.Because we will use Angular as a client-side on a different domain than the server’s domain, configuring CORS is mandatory.

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>  //we need to configure an IIS integration which will help us with the IIS deployment
            {
                //We do not initialize any of the properties inside the options because we are just fine with the default values. For more pieces of information about those properties


            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
        //Every time we want to use a logger service, all we need to do is to inject it into the constructor of the class that is going to use that service. .NET Core will serve that service from the IOC container and all of its features will be available to use. This type of injecting object is called Dependency Injection.

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString,
                MySqlServerVersion.LatestSupportedServerVersion));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}


//Dependency injection is a technique for achieving loose coupling between objects and their dependencies. 
//    It means that rather than instantiating an object every time it is needed, 
//    we can instantiate it once and then serve it in a class, most often, 
//    through a constructor method. This specific approach we utilize is also known as the Constructor Injection.

//In a system that is designed to use DI, you may find many classes requesting their dependencies via their constructor.

//In that case, it is helpful to have a class that will provide all instances to classes through the constructor.
//    These classes are referred to as containers or more specific Inversion of Control containers. 
//    An IOC container is essentially a factory that is responsible for providing instances of types that are requested from it.