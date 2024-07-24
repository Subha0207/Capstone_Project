using PizzaApp.Models.Enums;

namespace PizzaApp.Models
{
    public class Crust
    {
        public int CrustId { get; set; }
        public CrustName Name { get; set; }
        public decimal Cost { get; set; }
    }
}
