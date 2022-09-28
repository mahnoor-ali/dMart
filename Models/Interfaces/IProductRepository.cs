namespace DMART.Models.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
        public int AddProduct(Product product);
        public Product UpdateProduct(Product product);
        public void DeleteProduct(Product product);
        public (List<Product>, int) Search(String searchItem);
        public List<Product> getTopDeals();
        public List<Product> GetProductsByCategoryId(int id);
    }
}