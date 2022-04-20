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
    public class OrdersRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrdersRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateOrder(Order order)
        {
            Create(order);
        }

        public void DeleteOrder(Order order)
        {
            Delete(order);
        }

        public IEnumerable<Order> GetAllOrder(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.OrderId)
                .ToList();

        public Order GetOrder(int id, bool trackChanges) =>
            FindByCondition(c => c.OrderId.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateOrder(Order order)
        {
            Update(order);
        }
    }
}
