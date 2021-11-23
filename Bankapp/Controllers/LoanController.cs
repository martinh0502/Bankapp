using Bankapp.Core.Interfaces;
using Bankapp.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bankapp.Api.Controllers
{
    [Route("loans")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet("{id}")]
        public IActionResult GetLoans(int id)
        {
            List<Loan> list = _loanService.GetLoans(id);

            if (list == null) return NotFound();

            return Ok(list);
        }

        [HttpPost]
        public IActionResult PostLoan(Loan loan)
        {
            try
            {
                if (loan == null) return BadRequest("Invalid loan data");

                

                loan = _loanService.CreateLoan(loan);

                return Ok(loan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateLoanStatus(int loanId)
        {
            try
            {
                if (loanId < 1) return BadRequest("Ogiltig id");

                _loanService.UpdateLoanStatus(loanId);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
