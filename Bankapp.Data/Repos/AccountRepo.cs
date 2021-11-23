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
    public class AccountRepo : IAccountRepo
    {
        private readonly BankAppDataContext _context;

        public AccountRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public Account GetAccount(int accountId)
        {
            return _context.Accounts.Where(a => a.AccountId == accountId).SingleOrDefault();
        }

        public List<Account> GetAccounts(int customerId)
        {
            var customer = _context.Customers.Where(c => c.CustomerId == customerId).SingleOrDefault();
            var dispositions = _context.Dispositions.Where(d => d.CustomerId == customer.CustomerId).ToList();


            List<Account> accounts = new();

            foreach(var disposition in dispositions)
            {
                accounts.Add(_context.Accounts.Where(a => a.AccountId == disposition.AccountId).SingleOrDefault());
            }

            return accounts;
        }

        public Account PostAccount(Account account)
        {
            

            _context.Accounts.Add(account);
            _context.SaveChanges();

            return account;
        }

        public void UpdateBalance(int accountId, int amount)
        {
            Account account = _context.Accounts.Where(a => a.AccountId == accountId).SingleOrDefault();

            account.Balance = account.Balance + amount;

            _context.SaveChanges();
        }
    }
}
