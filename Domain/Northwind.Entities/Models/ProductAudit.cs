using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.Entities.Models
{
    public partial class ProductAudit
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? ChangesAt { get; set; }
        public string Activity { get; set; }
    }
}
