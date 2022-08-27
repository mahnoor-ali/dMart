using DMART.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DMART.Models.Repositories
{
    public class ProductRepository: IProductRepository
    {
        public List<Product> GetAllProducts()
        {
        }

        public Product GetProductByName(int id)
        {
        }
      
        
        public int AddProduct(Product product)
        {
        }

        public void UpdateProduct(Product product)
        {
        }
        
        public void DeleteProduct(Product product)
        {
        }
        

    }
}
