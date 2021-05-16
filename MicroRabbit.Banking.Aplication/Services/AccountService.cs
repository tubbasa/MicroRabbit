using System.Collections.Generic;
using MicroRabbit.Banking.Aplication.Interfaces;
using MicroRabbit.Banking.Aplication.Models;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Banking.Aplication.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;
        private readonly IEventBus _eventBus;

        public AccountService(IAccountRepository repo, IEventBus eventBus)
        {
            _repo = repo;
            _eventBus = eventBus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _repo.GetAcoounts();
        }

        public void TransferFunds(AccountTransfer accountTransfer)
        {
            CreateTransferCommand createTransfer = new CreateTransferCommand(accountTransfer.AccountSource,
                accountTransfer.AccountTarget, accountTransfer.TransferAmount);
            _eventBus.SendCommand(createTransfer);
        }
    }
}