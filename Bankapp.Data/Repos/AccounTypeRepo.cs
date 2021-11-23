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
    public class AccounTypeRepo : IAccountTypeRepo
    {
        private readonly BankAppDataContext _context;

        public AccounTypeRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public void PostAccountType(AccountType accountType)
        {
            _context.AccountTypes.Add(accountType);
            _context.SaveChanges();
        }
    }
}
