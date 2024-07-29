using PizzaApp.Contexts;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class BeverageRepository : BaseRepository<Beverage>
    {
        public BeverageRepository(PizzaAppContext context) : base(context)
        {
        }
    }
}
