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
    public class TransactionService:ITransactionService
    {
        private readonly ITransactionRepo _transactionRepo;
        private readonly IAccountRepo _accountRepo;

        public TransactionService(ITransactionRepo repository, IAccountRepo accountRepo)
        {
            _transactionRepo = repository;
            _accountRepo = accountRepo;
        }

        public bool CheckValidTransaction(int accountId, int targetAccount, int amount)
        {
            Account account = _accountRepo.GetAccount(accountId);

            if (account.Balance < amount) return false;

            if (_accountRepo.GetAccount(targetAccount) == null) return false;

            return true;
        }

        public List<Transaction> GetTransactions(int accountId)
        {
            return _transactionRepo.GetTransactions(accountId);
        }

        public void TransferMoney(int accountId, int targetAccount, int amount)
        {
            _transactionRepo.CreateTransaction(accountId, "transfer", -amount);
            _transactionRepo.CreateTransaction(targetAccount, "transfer", amount);
            _accountRepo.UpdateBalance(accountId, -amount);
            _accountRepo.UpdateBalance(targetAccount, amount);
        }
    }
}
