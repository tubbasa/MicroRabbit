using System.Threading.Tasks;
using MicroRabbit.Domain.Core.B;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;
        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }
        
        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
                { FromAccount = @event.TransferFrom, ToAccount = @event.TransferTo, TransferAmount = @event.TransferAmount });
            return  Task.CompletedTask;
        }
    }
}