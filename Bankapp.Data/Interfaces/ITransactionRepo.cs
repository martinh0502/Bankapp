using Bankapp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankapp.Data.Interfaces
{
    public interface ITransactionRepo
    {
        List<Transaction> GetTransactions(int accountId);

        void CreateTransaction(int accountId, string operation, int amount);

        
    }
}
