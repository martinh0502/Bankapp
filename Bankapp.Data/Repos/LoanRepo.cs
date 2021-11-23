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
    public class LoanRepo : ILoanRepo
    {
        private readonly BankAppDataContext _context;

        public LoanRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public Loan CreateLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();

            return loan;
        }

        public Loan GetLoan(int loanId)
        {
            return _context.Loans.Where(l => l.LoanId == loanId).SingleOrDefault();
        }

        public List<Loan> GetLoans(int accountId)
        {
            List<Loan> list = _context.Loans.Where(l => l.AccountId == accountId).ToList();

            return list;
        }

        public void UpdateLoanStatus(int loanId)
        {
            Loan loan = _context.Loans.Where(l => l.LoanId == loanId).SingleOrDefault();

            loan.Status = "Running";

            _context.SaveChanges();
        }
    }
}
