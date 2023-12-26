namespace Homezmart.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int QuantityOrdered { get; set; }
        public float Price { get; set; }
       
        public Product Product { get; set; } = null!;
        public Order Order { get; set; } = null!;
    }
}
