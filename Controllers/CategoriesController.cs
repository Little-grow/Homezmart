using Homezmart.DTO;
using Homezmart.Models.Categories;
using Homezmart.Models.DatabaseContext;
using Homezmart.Services.CategoriesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Homezmart.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // CRUD operations using category service

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetCategories();
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryDto category)
        {
            var newCategory = _categoryService.PostCategory(category);
            if (newCategory == null)
            {
                return BadRequest();
            }
            return Ok(newCategory);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryDto updatedCategory)
        {
            var category = _categoryService.PutCategory(id, updatedCategory);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.DeleteCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

    }
}
