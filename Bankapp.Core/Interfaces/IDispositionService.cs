using Bankapp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankapp.Core.Interfaces
{
    public interface IDispositionService
    {
        void PostDisposition(Disposition disposition);
    }
}
