using Bankapp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankapp.Core.Interfaces
{
    public interface ILoanService
    {
        List<Loan> GetLoans(int accountId);

        Loan CreateLoan(Loan loan);

        void UpdateLoanStatus(int loanId);
    }
}
