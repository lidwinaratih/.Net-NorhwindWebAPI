using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.DataTransferObject
{
    public class ShipDto
    {
        public int ShipVIa { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public DateTime ShippedDate { get; set; }
    }
}
