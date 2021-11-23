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
    [Route("accountypes")]
    [ApiController]

    
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeService _accountTypeService;

        public AccountTypeController(IAccountTypeService accountTypeService)
        {
            _accountTypeService = accountTypeService;
        }

        [HttpPost]
        public IActionResult PostAccountType(AccountType accountType)
        {
            try
            {
                if (accountType == null) return BadRequest("Invalid accountType data");

                _accountTypeService.PostAccountType(accountType);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
