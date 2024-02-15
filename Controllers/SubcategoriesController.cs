using Homezmart.DTO;
using Homezmart.Models.Categories;
using Homezmart.Models.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Composition;

namespace Homezmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubcategoriesController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetSubcategories()
        {
            var subcategories = _context.Subcategories
                                .Include(sub => sub.Products)
                                .ToList();
            return Ok(subcategories);
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult GetSubcategoriesByCategory(int categoryId)
        {
            var subcategories = _context.Subcategories
                                .Where(sub => sub.CategoryId == categoryId)
                                .ToList();
            return Ok(subcategories);
        }


        [HttpGet("{subcategoryId}")]
        public IActionResult GetSubcategoryById(int subcategoryId)
        {
            var subcategory = _context.Subcategories
                                .Include(sub => sub.Products)
                                .FirstOrDefault(sub => sub.Id == subcategoryId);
            return Ok(subcategory);
        }

        [HttpPost]
        public IActionResult PostSubCategory(SubcategoryDto subcategory)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == subcategory.CategoryId);

            if (category == null)
            {
                return NotFound();
            }

            var newSubcategory = new Subcategory
            {
                SubcategoryName = subcategory.SubcategoryName,
                CategoryId = subcategory.CategoryId
            };

            category.Subcategories.Add(newSubcategory);
            _context.Subcategories.Add(newSubcategory);
            _context.SaveChanges();

            return Ok(subcategory);
        }

        [HttpPut("{SubcategoryId}")]
        public IActionResult PutSubcategory(int SubcategoryId, SubcategoryDto updatedSubcategory)
        {
            var subcategory = _context.Subcategories.FirstOrDefault(sub => sub.Id == SubcategoryId);
            if (subcategory == null)
            {
                return NotFound();
            }

            subcategory.SubcategoryName = updatedSubcategory.SubcategoryName;
            subcategory.CategoryId = updatedSubcategory.CategoryId;
            _context.SaveChanges();
            return Ok(subcategory);
        }

        [HttpDelete("{SubcategoryId}")]
        public IActionResult DeleteSubcategory(int SubcategoryId)
        {
            var subcategory = _context.Subcategories.FirstOrDefault(sub => sub.Id == SubcategoryId);
            if (subcategory == null)
            {
                return NotFound();
            }

            _context.Subcategories.Remove(subcategory);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
