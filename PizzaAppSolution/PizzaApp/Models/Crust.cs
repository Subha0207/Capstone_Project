using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class Crust
    {
        [Key]
        public int CrustId { get; set; }

        [Required]
        [EnumDataType(typeof(CrustName))]
        public CrustName Name { get; set; }

        [Required]
   
        public decimal Cost { get; set; }
    }
}
