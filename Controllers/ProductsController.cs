using Homezmart.DTO;
using Homezmart.Models;
using Homezmart.Models.DatabaseContext;
using Homezmart.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homezmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private IProductService _ProductService;
        public ProductsController(IProductService productService)
        {
            _ProductService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _ProductService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _ProductService.GetById(id);
            return Ok(product);
        }

        [HttpPost("{CategoryId}")]
        public IActionResult PostProduct(int CategoryId, int? SubCategoryId,ProductDto product)
        {
            var newProduct = _ProductService.CreateProduct(CategoryId, SubCategoryId, product);
            return Ok(newProduct);
        }

        [HttpPut("{ProductId}")]
        public IActionResult PutProduct(int ProductId, ProductDto updatedProduct)
        {
            var product = _ProductService.UpdateProduct(ProductId, updatedProduct);
            return Ok(product);
        }

        [HttpPut("UpdateProductSubCategory/{ProductId}/{SubcategoryId}")] 
        public IActionResult UpdateProductSubCategory(int ProductId, int SubCategoryId)
        {
            var product = _ProductService.UpdateProductSubCategory(ProductId,SubCategoryId);
            return Ok(product);
        }

        [HttpPut("UpdateProductCategory/{ProductId}/{CategoryId}")]
        public IActionResult UpdateProductCategory(int ProductId, int CategoryId)
        {
            var product = _ProductService.UpdateProductCategory(ProductId, CategoryId);
            return Ok(product);
        }

        [HttpDelete("{ProductId}")]
        public IActionResult DeleteProduct(int ProductId)
        {
            var product = _ProductService.DeleteProduct(ProductId);
            return Ok(product);
        }

        [HttpGet("SearchProductsbyPrice/{categoryId}/{minPrice}/{maxPrice}")]
        public IActionResult SearchProductsbyPrice(int categoryId, decimal minPrice, decimal maxPrice)
        {
            List<Product> products = _ProductService.SearchProductsbyPrice(categoryId, minPrice, maxPrice);
            return Ok(products);
        }

        [HttpGet("SearchProductsbyName/{name}")]
        public IActionResult SearchProductsbyName(string name)
        {
            List<Product> products = _ProductService.SearchProductsbyName(name);
            return Ok(products);
        }

        [HttpGet("SearchProductsbyDescription/{description}")]
        public IActionResult SearchProductsbyDescription(string description)
        {
            List<Product> products = _ProductService.SearchProductsbyDescription(description);
            return Ok(products);
        }
    }
}
