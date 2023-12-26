using Homezmart.DTO;
using Homezmart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homezmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDBContext _context;
        public ProductsController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return Ok(product);
        }

        [HttpPost("{CategoryId}/{SubCategoryId}")]
        public IActionResult PostProduct(int CategoryId, int? SubCategoryId,ProductDto product)
        {
            var newProduct = new Product
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price, 
                StockQuantity = product.StockQuantity
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return Ok(newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product updatedProduct)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.ProductName = updatedProduct.ProductName;
            product.ProductDescription = updatedProduct.ProductDescription;
            product.Price = updatedProduct.Price;
            product.StockQuantity = updatedProduct.StockQuantity;

            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPut("UpdateProductSubCategory")] 
        public IActionResult UpdateProductSubCategory(int id, int SubCategoryId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

           var subCategory = _context.Subcategories.Find(SubCategoryId);
            if (subCategory == null)
            {
                return NotFound();
            }

            product.SubcategoryId = SubCategoryId;
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPut("UpdateProductCategory")]
        public IActionResult UpdateProductCategory(int id, int CategoryId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var category = _context.Categories.Find(CategoryId);
            if (category == null)
            {
                return NotFound();
            }

            product.CategoryId = CategoryId;
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok(product);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }
    }
}
