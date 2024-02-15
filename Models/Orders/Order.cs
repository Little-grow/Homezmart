using System.ComponentModel.DataAnnotations.Schema;
using Homezmart.Models.Payment;

namespace Homezmart.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string OrderDate { get; set; } = string.Empty;
        public string OrderTotal { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;

        public OrderStatus OrderStatus { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public DateTime ShippingDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public Address DeliveryAddress { get; set; } = null!;

        public string DeliveryPhoneNumber { get; set; } = string.Empty;
        public string DeliveryNotes { get; set; } = string.Empty;
    }
}
