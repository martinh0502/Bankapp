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
    public class DispositionRepo:IDispositionRepo
    {
        private readonly BankAppDataContext _context;

        public DispositionRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public void PostDisposition(Disposition disposition)
        {
            _context.Dispositions.Add(disposition);
            _context.SaveChanges();
        }
    }
}
