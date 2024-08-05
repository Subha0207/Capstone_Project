using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class SizeDTO
    {   public int SizeId { get; set; }
        [Required]
        [EnumDataType(typeof(SizeName))]
        public SizeName Name { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}
