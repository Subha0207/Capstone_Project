using PizzaApp.Contexts;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class ToppingRepository : BaseRepository<Topping>
    {
        public ToppingRepository(PizzaAppContext context) : base(context)
        {

        }
    }
}
