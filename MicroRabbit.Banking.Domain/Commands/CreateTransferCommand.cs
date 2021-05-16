namespace MicroRabbit.Banking.Domain.Commands
{
    public class CreateTransferCommand : TransferCommand
    {
        public CreateTransferCommand(int TransferFrom, int TransferTo, decimal Amount)
        {
            this.TransferFrom = TransferFrom;
            this.Amount = Amount;
            this.TransferTo = TransferTo;
        }
        
    }
}