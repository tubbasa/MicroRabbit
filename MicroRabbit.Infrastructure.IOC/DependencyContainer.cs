using MediatR;
using MicroRabbit.Banking.Aplication.Interfaces;
using MicroRabbit.Banking.Aplication.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infastructue.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infrastructure.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();
            
            //Domain Banking Commands
            //bunu yapar isek tek tek entegre etmemiz gerekecek.
          //  services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

          //ama refleciton ile bu startupın boş bile olsa tipini tarayarak bütün handlerları atayabiliriz.
            var domainAssembly = typeof(MicroRabbit.Banking.Domain.DomainStartup).Assembly;
            services.AddMediatR(domainAssembly);
            //Domain Banking Events
            
            //Application Layer
            services.AddTransient<IAccountService, AccountService>();
            
            //Data Layer
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
            
        }
    }
}