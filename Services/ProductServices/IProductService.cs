using Homezmart.DTO;
using Homezmart.Models;

namespace Homezmart.Services.ProductServices
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product? GetById(int id);
        Product CreateProduct(int catrgoryId,int? subCategoryId,ProductDto product);
        Product UpdateProduct(int id,ProductDto product);
        Product UpdateProductCategory(int id,int categoryId);
        Product UpdateProductSubCategory(int id,int subCategoryId);
        Product DeleteProduct(int id);
        List<Product> GetProductsByCategory(int categoryId);
        List<Product> GetProductsBySubCategory(int subCategoryId);
        List<Product> SearchProductsbyPrice(int categoryId, decimal minPrice, decimal maxPrice);
        List<Product> SearchProductsbyName(string name);
        List<Product> SearchProductsbyDescription(string description);
    }
}
