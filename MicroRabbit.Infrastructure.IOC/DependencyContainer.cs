using MediatR;
using MicroRabbit.Banking.Aplication.Interfaces;
using MicroRabbit.Banking.Aplication.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Events;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.B;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infastructue.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using  TransferEventHandler = MicroRabbit.Transfer.Domain.EventHandlers.TransferEventHandler;
using TransferCreatedEvent = MicroRabbit.Transfer.Domain.Events.TransferCreatedEvent;

namespace MicroRabbit.Infrastructure.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(),scopeFactory);
            });
            
            //subscripttions
            services.AddTransient<TransferEventHandler>();
            


            #region  Comment

              //Domain Banking Commands
                        //bunu yapar isek tek tek entegre etmemiz gerekecek.
                      //  services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();


            #endregion
          
          //Domain Events
          services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();
          
          //ama refleciton ile bu startupın boş bile olsa tipini tarayarak bütün handlerları atayabiliriz.
            var domainAssembly = typeof(MicroRabbit.Banking.Domain.DomainStartup).Assembly;
            var domainTransfer = typeof(MicroRabbit.Transfer.Domain.DomainStartup).Assembly;
            services.AddMediatR(domainAssembly);
            //Domain Banking Events
            
            //Application Layer
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();
            
            //Data Layer
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();

            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();

            
        }
    }
}