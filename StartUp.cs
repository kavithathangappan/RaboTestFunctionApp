using AutoMapper;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rabo_Test_FunctionApp.Data;
using Rabo_Test_FunctionApp.Service;
using System;


[assembly: FunctionsStartup(typeof(Rabo_Test_FunctionApp.StartUp))]
namespace Rabo_Test_FunctionApp
{
    public class StartUp : FunctionsStartup
    {


        public override void Configure(IFunctionsHostBuilder builder)
        {

            string connectionString = Environment.GetEnvironmentVariable("SqlConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString));

            builder.Services.AddOptions();

            var serviceBusConnectionString = Environment.GetEnvironmentVariable("ServiceBusConnection");

            //using AMQP as transport
            builder.Services.AddSingleton((s) => {
                return new ServiceBusClient(serviceBusConnectionString, new ServiceBusClientOptions() { TransportType = ServiceBusTransportType.AmqpWebSockets });
            });

            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IUserRepo, UserRepo>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

       
    }
}
