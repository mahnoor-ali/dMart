using DMART.Models.Interfaces;

namespace DMART.Models.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly DMARTContext context;
        public CategoryRepository()
        {
            context = new DMARTContext();
        }
        public List<Category> GetAllCategories()
        {
            List<Category> categories = context.Category.ToList();
            return categories;
        }
        public Category GetCategoryById(int id)
        {
            Category category = context.Category.Find(id);
            return category;
        }
        public int AddCategory(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
            return category.Id;
        }
        public Category UpdateCategory(Category category) //get category from database and update it with new values
        {
            int id = category.Id;
            Category categories = context.Category.FirstOrDefault(item => item.Id == id);
            if (categories != null)
            {
                categories.Name = category.Name;
                categories.ImageUrl = category.ImageUrl;
                context.SaveChanges();
            }
            return categories;
        }
        public void DeleteCategory(Category category)
        {
        }
    }
}
