using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int CartId { get; set; } 

        [Required]

        public decimal Amount { get; set; } 

        [Required]
       
        public PaymentMethod Method { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }
    }
}
