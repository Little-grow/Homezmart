using Homezmart.DTO;
using Homezmart.Models;
using Homezmart.Models.DatabaseContext;

namespace Homezmart.Services.ProductServices
{
    public class ProductService
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
        
    }
}
