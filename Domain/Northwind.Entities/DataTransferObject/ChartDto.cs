using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.DataTransferObject
{
    public class ChartDto
    {
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
    }
}
