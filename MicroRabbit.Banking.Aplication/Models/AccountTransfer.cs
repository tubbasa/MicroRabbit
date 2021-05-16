using System.Security.Principal;

namespace MicroRabbit.Banking.Aplication.Models
{
    public class AccountTransfer
    {
        public int AccountSource { get; set; }
        public int AccountTarget { get; set; }
        public decimal TransferAmount { get; set; }
    }
}