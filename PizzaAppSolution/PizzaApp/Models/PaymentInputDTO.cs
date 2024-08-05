using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class PaymentInputDTO
    {   public int UserId { get; set; }
        public int CartId { get; set; }



    

        [Required]
        public PaymentMethod Method { get; set; }

    }
}
