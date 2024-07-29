using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class Topping
    {
        [Key]
        public int ToppingId { get; set; }

        [Required]
        [EnumDataType(typeof(ToppingName))]
        public ToppingName Name { get; set; }

        [Required]
  
        public decimal Cost { get; set; }
    }
}
