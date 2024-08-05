using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models.DTOs
{
    public class OrderGetDTO
    {
        public int OrderId { get; set; }


        public int PaymentId { get; set; }

        public int CartId { get; set; }


        [Required]
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; } = OrderStatus.OrderPlaced;

        [Required]
        public int UserId { get; set; }


        [Required]
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
