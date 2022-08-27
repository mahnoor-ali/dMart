namespace DMART.Models.Interfaces
{
    public interface IProductRepository
    {

        public List<Product> GetAllProducts();
        public Product GetProductByName(int id);
        public int AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);
    }
}
