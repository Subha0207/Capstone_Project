using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Exceptions;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class PizzaRepository : BaseRepository<Pizza>
    {
        private readonly PizzaAppContext _context;

        public PizzaRepository(PizzaAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Pizza> GetPizzaByPizzaId(int pizzaId)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(u => u.PizzaId == pizzaId);
            if (pizza == null)
            {
                throw new NotFoundException("Pizza not found");
            }
            return pizza;
        }
    }
}
