using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Exceptions;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class SizeRepository : BaseRepository<Size>
    {
        private readonly PizzaAppContext _context;

        public SizeRepository(PizzaAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Size> GetSizeBySizeId(int sizeId)
        {
            var size = await _context.Sizes.FirstOrDefaultAsync(u => u.SizeId == sizeId);
            if (size == null)
            {
                throw new NotFoundException("Size not found");
            }
            return size;
        }
    }
}
