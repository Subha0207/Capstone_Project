using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Exceptions;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class BeverageRepository : BaseRepository<Beverage>
    {
        private readonly PizzaAppContext _context;

        public BeverageRepository(PizzaAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Beverage> GetBeverageByBeverageId(int beverageId)
        {
            var beverage = await _context.Beverages.FirstOrDefaultAsync(u => u.BeverageId == beverageId);
            if (beverage == null)
            {
                throw new NotFoundException("Beverage not found");
            }
            return beverage;
        }
    }
}
