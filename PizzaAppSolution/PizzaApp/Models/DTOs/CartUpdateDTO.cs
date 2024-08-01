using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models.DTOs
{
    public class CartUpdateDTO
    {
        public int CartId { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]

        public bool IsCheckedOut { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
