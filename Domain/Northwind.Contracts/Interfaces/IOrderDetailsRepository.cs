using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Interfaces
{
    public interface IOrderDetailsRepository
    {
        IEnumerable<OrderDetail> GetAllOrderDetail(bool trackChanges);
        OrderDetail GetOrderDetail(int orderId, int productId, bool trackChanges);
        void CreateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
    }
}
