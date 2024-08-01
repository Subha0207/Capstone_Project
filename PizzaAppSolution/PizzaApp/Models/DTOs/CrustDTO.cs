using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models.DTOs
{
    public class CrustDTO
    {

        [Required]
        [EnumDataType(typeof(CrustName))]
        public CrustName Name { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}
