namespace Homezmart.Models.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public List<Subcategory> Subcategories { get; set; } = new List<Subcategory>();

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
