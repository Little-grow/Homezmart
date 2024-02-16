using Homezmart.DTO;
using Homezmart.Models.Categories;

namespace Homezmart.Services.CategoriesServices
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category? GetCategory(int id);
        Category? PostCategory(CategoryDto category);
        Category? PutCategory(int id, CategoryDto updatedCategory);
        Category? DeleteCategory(int id);
    }
}
