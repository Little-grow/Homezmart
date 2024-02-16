using Homezmart.DTO;
using Homezmart.Models;
using Homezmart.Models.DatabaseContext;

namespace Homezmart.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product CreateProduct(int catrgoryId,int? subCategoryId,ProductDto product)
        {
            var category = _context.Categories.Find(catrgoryId);
            if (category == null)
            {
                throw new Exception("Category not found");
            }

            if (subCategoryId != null)
            {
                var subCategory = _context.Subcategories.Find(subCategoryId);
                if (subCategory == null)
                {
                    throw new Exception("Subcategory not found");
                }
            }

            var newProduct = new Product
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryId = category.Id,
                SubcategoryId = subCategoryId
            };
            
            _context.Products.Add(newProduct);  
            _context.SaveChanges();
            return newProduct;
        }

        public Product UpdateProduct(int id,ProductDto product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductDescription = product.ProductDescription;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;

            _context.SaveChanges();
            return existingProduct;
        }

        public Product UpdateProductCategory(int id, int categoryId)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            var category = _context.Categories.Find(categoryId);
            if (category == null)
            {
                throw new Exception("Category not found");
            }

            existingProduct.CategoryId = category.Id;
            _context.SaveChanges();
            return existingProduct;
        }

        public Product UpdateProductSubCategory(int id, int subCategoryId)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            var subCategory = _context.Subcategories.Find(subCategoryId);
            if (subCategory == null)
            {
                throw new Exception("Subcategory not found");
            }

            existingProduct.SubcategoryId = subCategory.Id;
            _context.SaveChanges();
            return existingProduct;
        }   

        public Product DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }
        
        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetProductsBySubCategory(int subCategoryId)
        {
            return _context.Products.Where(p => p.SubcategoryId == subCategoryId).ToList();
        }

        public List<Product> SearchProductsbyPrice (int categoryId,decimal minPrice, decimal maxPrice)
        {
            var products = GetProductsByCategory(categoryId);
            return products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        } 

        public List<Product> SearchProductsbyName (string name)
        {
            return _context.Products.Where(p => p.ProductName.Contains(name)).ToList();
        }

        public List<Product> SearchProductsbyDescription (string description)
        {
            return _context.Products.Where(p => p.ProductDescription.Contains(description)).ToList();
        }   
    }
}
