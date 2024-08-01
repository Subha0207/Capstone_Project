using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Exceptions;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class CrustRepository : BaseRepository<Crust>
    {
        private readonly PizzaAppContext _context;

        public CrustRepository(PizzaAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Crust> GetCrustByCrustId(int crustId)
        {
            var crust = await _context.Crusts.FirstOrDefaultAsync(u => u.CrustId == crustId);
            if (crust == null)
            {
                throw new NotFoundException("Crust not found");
            }
            return crust;
        }
    }
}
