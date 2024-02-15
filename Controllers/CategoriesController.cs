using Homezmart.DTO;
using Homezmart.Models.Categories;
using Homezmart.Models.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Homezmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories
                             .Include(c => c.Subcategories)
                             .Include(c => c.Products)
                             .ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories
                            .Include(c => c.Subcategories)
                            .Include(c => c.Products)
                            .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult PostCategory(CategoryDto category)
        {
            var newCategory = new Category
            {
                CategoryName = category.CategoryName
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return Ok(newCategory);
        }

        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, CategoryDto updatedCategory)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            category.CategoryName = updatedCategory.CategoryName;
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok(category);
        }
    }
}
