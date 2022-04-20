using Northwind.Entities.DataTransferObject;
using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.ServiceChart
{
    public interface IChartService
    {
        Tuple<int, IEnumerable<Product>, string> GetAllProduct(bool trackChanges);
        OrderDetail AddToChart(int productId, int quantity, string customerID);
        Order Checkout(int id);
        Order ShipOrder(ShipDto shipDto, int id);
    }
}
