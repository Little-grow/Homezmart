using System.ComponentModel.DataAnnotations;

namespace Homezmart.DTO
{
    public class SubcategoryDto
    {
        public string SubcategoryName { get; set; } = string.Empty;
        [Required]
        public int CategoryId { get; set; }
    }
}