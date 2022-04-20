using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities.Models;
using Northwind.Contracts.Interfaces;
using Northwind.Entities.Contexts;

namespace Northwind.Repository.Models
{
    public class CustomersRepository : RepositoryBase<Customer>, ICustomersRepository
    {
        public CustomersRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            Delete(customer);
        }

        public IEnumerable<Customer> GetAllCustomer(bool trackChanges) => 
            FindAll(trackChanges)
                .OrderBy(c => c.CustomerId)
                .ToList();

        public Customer GetCustomer(string id, bool trackChanges) =>
            FindByCondition(c => c.CustomerId.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateCustomer(Customer customer)
        {
            Update(customer);
        }
    }
}
