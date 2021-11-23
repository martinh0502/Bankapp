using Bankapp.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Bankapp.Api.Controllers
{
    [Route("transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{id}")]
        public IActionResult GetTransactions(int id)
        {
            var list = _transactionService.GetTransactions(id);

            return Ok(list);
        }

        [HttpPost]
        public IActionResult TransferMoney(int account, int targetAccount, int amount)
        {
            try
            {
                if (_transactionService.CheckValidTransaction(account, targetAccount, amount) == false) return BadRequest("Could not transfer");


                _transactionService.TransferMoney(account, targetAccount, amount);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
