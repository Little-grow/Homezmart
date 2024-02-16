using Homezmart.DTO;
using Homezmart.Models.Categories;
using Homezmart.Models.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Homezmart.Services.CategoriesServices
{
    public class CategoryService: ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            var categories = _context.Categories
                             .Include(c => c.Subcategories)
                             .Include(c => c.Products)
                             .ToList();

            return categories;
        }

        public Category? GetCategory(int id)
        {
            var category = _context.Categories
                            .Include(c => c.Subcategories)
                            .Include(c => c.Products)
                            .FirstOrDefault(c => c.Id == id);

            return category;
        }

        public Category? PostCategory(CategoryDto category)
        {
            var newCategory = new Category
            {
                CategoryName = category.CategoryName
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return newCategory;
        }

        public Category? PutCategory(int id, CategoryDto updatedCategory)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return null;
            }
            category.CategoryName = updatedCategory.CategoryName;
            _context.SaveChanges();
            return category;
        }

        public Category? DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return null;
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }
    }
}
