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
    public class CustomerRepo : ICustomerRepo
    {
        private readonly BankAppDataContext _context;

        public CustomerRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public Customer CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public Customer GetCustomer(int customerId)
        {
            Customer customer = _context.Customers.Where(c => c.CustomerId == customerId).SingleOrDefault();

            return customer;
        }

        public List<Customer> GetCustomersName(string name)
        {
            List<Customer> list = _context.Customers.Where(c => c.Givenname.Contains(name)).ToList();

            return list;
        }
    }
}
