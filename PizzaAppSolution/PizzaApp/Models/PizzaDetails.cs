namespace PizzaApp.Models
{
    public class PizzaDetails
    {

        public int PizzaDetailsId { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int CrustId { get; set; }
        public Crust Crust { get; set; }
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }
        
    }
}
