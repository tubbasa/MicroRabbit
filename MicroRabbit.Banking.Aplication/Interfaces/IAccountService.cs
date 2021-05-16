using System.Collections.Generic;
using MicroRabbit.Banking.Aplication.Models;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Aplication.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();

        void TransferFunds(AccountTransfer accountTransfer);
    }
}