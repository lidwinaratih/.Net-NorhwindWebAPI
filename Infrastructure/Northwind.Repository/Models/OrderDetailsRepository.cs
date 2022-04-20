using Northwind.Contracts.Interfaces;
using Northwind.Entities.Contexts;
using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repository.Models
{
    public class OrderDetailsRepository : RepositoryBase<OrderDetail>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            Create(orderDetail);
        }

        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            Delete(orderDetail);
        }

        public IEnumerable<OrderDetail> GetAllOrderDetail(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.OrderId)
                .ToList();

        public OrderDetail GetOrderDetail(int id, int proID, bool trackChanges) =>
            FindByCondition(c => c.OrderId.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            Update(orderDetail);
        }
    }
}
