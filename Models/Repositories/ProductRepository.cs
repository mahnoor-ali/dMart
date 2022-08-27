using DMART.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DMART.Models.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly DMARTContext context;
        public ProductRepository()
        {
            context = new DMARTContext();
        }
        
        public List<Product> GetAllProducts()
        {
            List<Product> products = context.Products.ToList();
            return products;
        }

        public Product GetProductById(int id)
        {
            Product product = context.Products.Find(id);
            return product;
        }
      
        public int AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product.Id;
        }

        public Product UpdateProduct(Product product) //get product from database and update it with new values
        {
            int id = product.Id;
            Product products = context.Products.FirstOrDefault(item => item.Id == id);
            if (products!=null)
            {
                products.Price=product.Price;
                products.Quantity=product.Quantity;
                products.DiscountPercentage=product.DiscountPercentage;
                products.Name=product.Name;
                products.CategoryId=product.CategoryId;
                products.Description=product.Description;
                products.Discount=product.Discount;
                products.Image=product.Image;
                context.SaveChanges();
            }
            return products;
        }
        
        public void DeleteProduct(Product product)
        {
        }
        
        public List<Product> Search(String searchItem)
        {
            if (searchItem == null)
            {
                return GetAllProducts();
            }
            else
            {
                return context.Products.Where(p => p.Name.ToLower().Contains(searchItem.ToLower())).ToList();
            }
        }

        public int AddCategory(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
            return category.Id;
        }

    }
}
