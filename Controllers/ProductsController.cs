using Homezmart.DTO;
using Homezmart.Models;
using Homezmart.Models.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace Homezmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
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


        [HttpPost("{CategoryId}")]
        public IActionResult PostProduct(int CategoryId, int? SubCategoryId,ProductDto product)
        {
            var category = _context.Categories.Find(CategoryId);
            if (category == null)
            {
                return NotFound();
            }

            if (SubCategoryId != null)
            {
                var subCategory = _context.Subcategories.Find(SubCategoryId);
                if (subCategory == null)
                {
                    return NotFound();
                }
            }

            var newProduct = new Product
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price, 
                StockQuantity = product.StockQuantity, 
                CategoryId = category.Id,
                SubcategoryId = SubCategoryId
            };


            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return Ok(newProduct);
        }

        [HttpPut("{ProductId}")]
        public IActionResult PutProduct(int ProductId, ProductDto updatedProduct)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == ProductId);
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

        [HttpPut("UpdateProductSubCategory/{ProductId}/{SubcategoryId}")] 
        public IActionResult UpdateProductSubCategory(int ProductId, int SubCategoryId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == ProductId);
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

        [HttpPut("UpdateProductCategory/{ProductId}/{CategoryId}")]
        public IActionResult UpdateProductCategory(int ProductId, int CategoryId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == ProductId);
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


        [HttpDelete("{ProductId}")]
        public IActionResult DeleteProduct(int ProductId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == ProductId);
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
