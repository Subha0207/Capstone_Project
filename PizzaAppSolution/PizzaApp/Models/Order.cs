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
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }


        [Required]
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

    }
}
