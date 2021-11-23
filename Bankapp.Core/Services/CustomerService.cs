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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _repository;

        public CustomerService(ICustomerRepo repository)
        {
            _repository = repository;
        }

        public Customer CreateCustomer(Customer customer)
        {
            customer = _repository.CreateCustomer(customer);

            return customer;
        }

        public Customer GetCustomer(int customerId)
        {
            return _repository.GetCustomer(customerId);
        }

        public List<Customer> GetCustomersName(string name)
        {
            return _repository.GetCustomersName(name);
        }
    }
}
