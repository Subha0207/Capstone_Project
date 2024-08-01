using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models.DTOs
{
    public class CartItemPizzaInputDTO
    {
        public int UserId { get; set; }


        public int PizzaId { get; set; }

        public int CrustId { get; set; }

        public int ToppingId { get; set; }

        public int SizeId { get; set; }
      





    }
}
