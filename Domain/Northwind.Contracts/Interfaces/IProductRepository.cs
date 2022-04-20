using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct(bool trackChanges);
        Product GetProduct(int id, bool trackChanges);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
    }
}
