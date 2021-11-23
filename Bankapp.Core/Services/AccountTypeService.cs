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
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IAccountTypeRepo _accountTypeRepo;

        public AccountTypeService(IAccountTypeRepo accountTypeRepo)
        {
            _accountTypeRepo = accountTypeRepo;
        }

        public void PostAccountType(AccountType accountType)
        {
            _accountTypeRepo.PostAccountType(accountType);
        }
    }
}
