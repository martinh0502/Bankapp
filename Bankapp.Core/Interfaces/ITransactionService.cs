using Bankapp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankapp.Core.Interfaces
{
    public interface ITransactionService
    {
        List<Transaction> GetTransactions(int accountId);

        void TransferMoney(int accountId, int targetAccount, int amount);

        bool CheckValidTransaction(int accountId, int targetAccount, int amount);
    }
}
