using MicroRabbit.Domain.Core.Commands;

namespace MicroRabbit.Banking.Domain.Commands
{
    public abstract class TransferCommand : Command
    {
        public int TransferFrom { get; protected set; }
        public int TransferTo { get; protected set; }
        public decimal Amount { get; protected set; }

    }
}