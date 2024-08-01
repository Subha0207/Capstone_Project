using PizzaApp.Models.DTOs;
using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class OrderDTO
    {


        public string PaymentId { get; set; }
     
        public int CartId { get; set; }
     

        [Required]
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; } = OrderStatus.OrderPlaced;

        [Required]
        public int UserId { get; set; }
 

        [Required]
        public DateTime OrderDate { get; set; }
    }
}
