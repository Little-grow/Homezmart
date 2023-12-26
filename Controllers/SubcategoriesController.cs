using Homezmart.DTO;
using Homezmart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Composition;

namespace Homezmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public SubcategoriesController(AppDBContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public IActionResult GetSubcategory(int id)
        {
            var subcategory = _context.Subcategories
                                .Include(sub => sub.Products)
                                .FirstOrDefault(sub => sub.Id == id);
            return Ok(subcategory);
        }


        [HttpPost("{CategoryId}")]
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


        [HttpPut("{id}")]
        public IActionResult PutSubcategory(int id, Subcategory subcategory )
        {
            var sub = _context.Subcategories.FirstOrDefault(sub => sub.Id == id);
            if (sub == null)
            {
                return NotFound();
            }

            sub.SubcategoryName = subcategory.SubcategoryName;
            _context.SaveChanges();
            return Ok(sub);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteSubcategory(int id)
        {
            var subcategory = _context.Subcategories.FirstOrDefault(sub => sub.Id == id);
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
