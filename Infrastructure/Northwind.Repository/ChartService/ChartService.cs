using Northwind.Contracts;
using Northwind.Contracts.ServiceChart;
using Northwind.Entities.DataTransferObject;
using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repository.CartService
{
    public class ChartService : IChartService
    {
        private readonly IRepositoryManager _repository;

        public ChartService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public Tuple<int, IEnumerable<Product>, string> GetAllProduct(bool trackChanges)
        {
            IEnumerable<Product> products1 = null;

            try
            {
                IEnumerable<Product> products = _repository.Products.GetAllProduct(trackChanges: false);

                return Tuple.Create(1, products, "success");
            }
            catch (Exception ex)
            {
                return Tuple.Create(-1, products1, ex.Message);
            }
        }

        public OrderDetail AddToChart(int productId, int quantity, string customerID)
        {
            Order order = new Order();
            Product product = new Product();
            OrderDetail orderDetail = new OrderDetail();
            Customer customer = new Customer();

            try
            {
                product = _repository.Products.GetProduct(productId, trackChanges: false);
                order = _repository.Orders.GetAllOrder(trackChanges: true).Where(c => c.CustomerId == customerID && c.ShippedDate == null).SingleOrDefault();

                if (order == null)
                {
                    order = new Order();
                    order.CustomerId = customerID;
                    order.OrderDate = DateTime.Now;
                    _repository.Orders.CreateOrder(order);
                    _repository.Save();
                }

                orderDetail = _repository.OrderDetails.GetOrderDetail(order.OrderId, productId, trackChanges: true);

                if (orderDetail == null)
                {
                    orderDetail = new OrderDetail();
                    orderDetail.OrderId = order.OrderId;
                    orderDetail.ProductId = productId;
                    orderDetail.UnitPrice = (decimal)((decimal)product.UnitPrice * quantity);
                    orderDetail.Quantity = (short)quantity;
                    //orderDetail.Discount = (real)product.Discontinued;

                    _repository.OrderDetails.CreateOrderDetail(orderDetail);
                    _repository.Save();
                }

                else
                {
                    if (orderDetail.Quantity == null)
                    {
                        orderDetail.Quantity = (short)quantity;
                        orderDetail.UnitPrice = (decimal)((decimal)product.UnitPrice * quantity);
                    }
                    else
                    {
                        orderDetail.Quantity += (short)quantity;
                        orderDetail.UnitPrice += (decimal)((decimal)product.UnitPrice * quantity);
                    }

                    _repository.OrderDetails.UpdateOrderDetail(orderDetail);
                    _repository.Save();
                }

                return orderDetail;
            }
            catch (Exception ex)
            {
                return orderDetail;
            }
        }

        public Order Checkout(int id)
        {
            throw new NotImplementedException();
        }

        public Order ShipOrder(ShipDto shipDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
