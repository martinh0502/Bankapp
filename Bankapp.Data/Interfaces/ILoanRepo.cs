using Bankapp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankapp.Data.Interfaces
{
    public interface ILoanRepo
    {
        List<Loan> GetLoans(int accountId);

        Loan GetLoan(int loanId);

        Loan CreateLoan(Loan loan);

        void UpdateLoanStatus(int loanId);
    }
}
