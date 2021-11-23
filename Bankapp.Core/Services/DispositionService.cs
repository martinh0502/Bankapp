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
    public class DispositionService : IDispositionService
    {
        private readonly IDispositionRepo _repo;

        public DispositionService(IDispositionRepo repo)
        {
            _repo = repo;
        }

        public void PostDisposition(Disposition disposition)
        {
            disposition.Type = "OWNER";
            _repo.PostDisposition(disposition);
            
        }
    }
}
