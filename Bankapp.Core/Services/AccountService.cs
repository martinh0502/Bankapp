using Bankapp.Core.Interfaces;
using Bankapp.Data.Interfaces;
using Bankapp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankapp.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _repository;

        public AccountService(IAccountRepo repository)
        {
            _repository = repository;
        }

        public List<Account> GetAccounts(int customerId)
        {
            return _repository.GetAccounts(customerId);
        }

        public Account PostAccount(Account account)
        {
            account.AccountTypesId = 1;
            account.Balance = 0;
            account.Created = DateTime.UtcNow;
            account.Frequency = "Monthly";

            return _repository.PostAccount(account);
        }
    }
}
