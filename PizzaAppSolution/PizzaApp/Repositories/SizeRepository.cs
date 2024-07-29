using PizzaApp.Contexts;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class SizeRepository : BaseRepository<Size>
    {
        public SizeRepository(PizzaAppContext context) : base(context)
        {

        }
    }
}
