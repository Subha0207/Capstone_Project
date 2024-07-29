using PizzaApp.Contexts;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class CartRepository : BaseRepository<Cart>
    {
        public CartRepository(PizzaAppContext context) : base(context)
        {
        }
    }
}
