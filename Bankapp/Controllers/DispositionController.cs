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
    [Route("dispositions")]
    [ApiController]
    public class DispositionController : ControllerBase
    {
        private readonly IDispositionService _dispositionService;

        public DispositionController(IDispositionService dispositionService)
        {
            _dispositionService = dispositionService;
        }

        [HttpPost]
        public IActionResult PostDisposition(Disposition disposition)
        {
            try
            {
                if (disposition == null) return BadRequest("Invalid disposition data");

                _dispositionService.PostDisposition(disposition);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
