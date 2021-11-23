using Bankapp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankapp.Data.Interfaces
{
    public interface ICustomerRepo
    {
        Customer GetCustomer(int customerId);

        Customer CreateCustomer(Customer customer);

        List<Customer> GetCustomersName(string name);
    }
}
