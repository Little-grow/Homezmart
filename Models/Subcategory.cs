namespace Homezmart.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string SubcategoryName { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public List<Product> Products { get; set; } =null!;
    }
}
