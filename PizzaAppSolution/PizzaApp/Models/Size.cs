using PizzaApp.Models.Enums;

namespace PizzaApp.Models
{
    public class Size
    {
        public int SizeId { get; set; }
        public  SizeName Name { get; set; }
        public decimal Cost { get; set; }
    }
}
