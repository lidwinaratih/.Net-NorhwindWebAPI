using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Interfaces
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetAllCustomer(bool trackChanges);
        Customer GetCustomer(string id, bool trackChanges);
        void CreateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
    }
}
