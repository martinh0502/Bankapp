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
    [Route("accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{id}")]
        public IActionResult GetAccounts(int id)
        {
            var list = _accountService.GetAccounts(id);

            return Ok(list);
        }

        [HttpPost]
        public IActionResult PostAccount(Account account)
        {
            try
            {
                if (account == null) return BadRequest("Invalid account data");

                account = _accountService.PostAccount(account);

                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
