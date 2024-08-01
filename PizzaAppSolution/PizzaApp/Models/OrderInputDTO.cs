using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class OrderInputDTO
    {

        public string PaymentId { get; set; }

        public int CartId { get; set; }


        [Required]
        public int UserId { get; set; }


    }
}
