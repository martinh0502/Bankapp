using Bankapp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankapp.Data.Interfaces
{
    public interface IAccountRepo
    {
        List<Account> GetAccounts(int customerId);

        void UpdateBalance(int accountId, int amount);

        Account GetAccount(int accountId);

        Account PostAccount(Account account);
    }
}
