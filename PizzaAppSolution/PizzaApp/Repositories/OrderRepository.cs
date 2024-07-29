using PizzaApp.Contexts;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(PizzaAppContext context) : base(context)
        {
        }
    }
}
