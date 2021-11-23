using Bankapp.Data.EFModels;
using Bankapp.Data.Interfaces;
using Bankapp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankapp.Data.Repos
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly BankAppDataContext _context;

        public TransactionRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public void CreateTransaction(int accountId, string operation, int amount)
        {
            Transaction transaction = new();
            Account account = _context.Accounts.Where(a => a.AccountId == accountId).SingleOrDefault();

            transaction.AccountId = accountId;
            transaction.Operation = operation;
            transaction.Amount = amount;
            transaction.Balance = account.Balance + amount;
            transaction.Date = DateTime.UtcNow;
            transaction.Type = "Credit";

            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public List<Transaction> GetTransactions(int accountId)
        {
            List<Transaction> list = new();

            list = _context.Transactions.Where(t => t.AccountId == accountId).ToList();


            list = list.OrderByDescending(a => a.TransactionId).ToList();

            if(list.Count > 10)
            {
                list = list.GetRange(0, 10).ToList();
            }

            

            return list;
        }
    }
}
