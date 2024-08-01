using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Exceptions;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class ToppingRepository : BaseRepository<Topping>
    {
        private readonly PizzaAppContext _context;

        public ToppingRepository(PizzaAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Topping> GetToppingByToppingId(int toppingId)
        {
            var topping = await _context.Toppings.FirstOrDefaultAsync(u => u.ToppingId == toppingId);
            if (topping == null)
            {
                throw new NotFoundException("Topping not found");
            }
            return topping;
        }
    }
}
