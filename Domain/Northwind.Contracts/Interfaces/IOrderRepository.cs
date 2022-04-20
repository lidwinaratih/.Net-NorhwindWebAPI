using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrder(bool trackChanges);
        Order GetOrder(int id, bool trackChanges);
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
        void UpdateOrder(Order order);
    }
}
