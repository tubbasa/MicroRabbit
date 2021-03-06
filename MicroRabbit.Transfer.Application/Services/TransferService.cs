using System.Collections.Generic;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using MicroRabbit.Transfer.Domain.Models;
using  MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Interfaces;

namespace MicroRabbit.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {

        private readonly ITransferRepository _transferRepo;
        private readonly IEventBus _bus;

        public TransferService(ITransferRepository transferRepository,IEventBus bus)
        {
            _transferRepo = transferRepository;
            _bus = bus;
        }
        
        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepo.GetTransferLogs();
        }
    }
}