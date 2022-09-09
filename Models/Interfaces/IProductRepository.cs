namespace DMART.Models.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
        public int AddProduct(Product product);
        public Product UpdateProduct(Product product);
        public void DeleteProduct(Product product);
        public int AddCategory(Category category);
        public (List<Product>, int) Search(String searchItem);
    }
}