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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        public IEnumerable<Product> GetAllProduct(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.ProductId)
                .ToList();

        public Product GetProduct(int id, bool trackChanges) =>
            FindByCondition(c => c.ProductId.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateProduct(Product product)
        {
            Update(product);
        }
    }
}
