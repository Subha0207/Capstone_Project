using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models.DTOs
{
    public class CartItemBeverageInputDTO
    {
        public int UserId { get; set; }
        public int BeverageId { get; set; }
     
       
    }
}
