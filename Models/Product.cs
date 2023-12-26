using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Homezmart.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;

        //[JsonIgnore]
        //public string ProductImage { get; set; } = string.Empty;

        //[NotMapped]
        //public IFormFile ProductImg { get; set; }
        
        public int CategoryId { get; set; }

        public int? SubcategoryId { get; set; }
 
        public float Price { get; set; }    
        public int StockQuantity { get; set; }
    }
}
