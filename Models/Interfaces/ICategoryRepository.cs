namespace DMART.Models.Interfaces
{
    public interface ICategoryRepository
    {
        public List<Category> GetAllCategories();
        public Category GetCategoryById(int id);
        public int AddCategory(Category category);
        public Category UpdateCategory(Category category);
        public void DeleteCategory(Category category);
    }
}
