using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.Banking.Domain.Events
{
    public class TransferCreatedEvent : Event
    {
        public int TransferFrom { get; private set; }
        public int TransferTo { get; private set; }
        public decimal TransferAmount { get; private set; }

        public TransferCreatedEvent(int transferFrom, int transferTo, decimal transferAmount)
        {
            TransferFrom = transferFrom;
            TransferTo = transferTo;
            TransferAmount = transferAmount;
        }
    }
}