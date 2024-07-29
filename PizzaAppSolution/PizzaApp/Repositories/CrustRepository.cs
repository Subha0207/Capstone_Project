using PizzaApp.Contexts;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class CrustRepository : BaseRepository<Crust>
    {
        public CrustRepository(PizzaAppContext context) : base(context)
        {

        }
    }
}
