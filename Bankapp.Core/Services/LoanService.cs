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
    public class LoanService : ILoanService
    {
        private readonly ILoanRepo _repository;
        private readonly IAccountRepo _accountRepo;

        public LoanService(ILoanRepo repository, IAccountRepo accountRepo)
        {
            _repository = repository;
            _accountRepo = accountRepo;
        }

        public Loan CreateLoan(Loan loan)
        {
            loan.Date = DateTime.UtcNow;
            loan.Payments = loan.Amount / loan.Duration;
            loan.Status = "Not approved";

            return _repository.CreateLoan(loan);
        }

        public List<Loan> GetLoans(int accountId)
        {
            return _repository.GetLoans(accountId);
        }

        public void UpdateLoanStatus(int loanId)
        {
            Loan loan = _repository.GetLoan(loanId);

            _accountRepo.UpdateBalance(loan.AccountId, Convert.ToInt32(loan.Amount));


            _repository.UpdateLoanStatus(loanId);
        }
    }
}
