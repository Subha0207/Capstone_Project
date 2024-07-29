using PizzaApp.Contexts;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class PizzaRepository : BaseRepository<Pizza>
    {
        public PizzaRepository(PizzaAppContext context) : base(context)
        {

        }
    }
}
