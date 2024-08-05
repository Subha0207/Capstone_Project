using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class OrderInputDTO
    {

        public int PaymentId { get; set; }

        public int CartId { get; set; }


        [Required]
        public int? UserId { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }


    }
}
