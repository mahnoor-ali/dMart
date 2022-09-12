using DMART.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DMART.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DMARTContext context;
        public ProductRepository()
        {
            context = new DMARTContext();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = context.Products.OrderBy(item => item.Name).ToList();
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
                products.ImageUrl=product.ImageUrl;
                context.SaveChanges();
            }
            return products;
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();

        }

        public (List<Product>, int) Search(String searchItem)
        {
            /*
            List<Product> searchResult = context.Products.Where(product => (product.Name.ToLower().Contains(searchItem.ToLower())) || (product.Id>0 )).Select(product => product).ToList();
            if (searchResult.Count==1)
            {
             searchResult = context.Products.Where(product => product.Name.ToLower().Contains(searchItem.ToLower())).Select(product => product).ToList();
            } 
             */
            List<Product> searchResult = new List<Product>();
            var item = context.Products.Where(product => product.Name.ToLower().Contains(searchItem.ToLower()));
            int count = 0;
            if (item.Any()) //if any product is found
            {
                searchResult = context.Products.Where(product => (product.Name.ToLower().Contains(searchItem.ToLower()))).Select(product => product).ToList();
                count = searchResult.Count;
            }
            else
            {
                searchResult = context.Products.Where(product => (product.Id > 0)).Select(product => product).ToList();
            }
            return (searchResult, count);
        }

        public int AddCategory(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
            return category.Id;
        }

        public List<Product> getTopDeals()
        {
            List<Product> topDeals = context.Products.Where(product => product.CategoryId.Equals("17")).Take(1).ToList();
            return topDeals;
        }

    }
}
