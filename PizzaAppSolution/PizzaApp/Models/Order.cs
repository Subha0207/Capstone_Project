using PizzaApp.Models.DTOs;
using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string PaymentId { get; set; }
        public Payment Payment { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }


        [Required]
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; }

        [Required]
        public int UserId { get; set; }
        public UserDTO User { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

    }
}
