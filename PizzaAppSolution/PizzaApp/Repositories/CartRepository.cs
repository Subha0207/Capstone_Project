using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Exceptions;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class CartRepository : BaseRepository<Cart>
    {
        private readonly PizzaAppContext _context;

        public CartRepository(PizzaAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cart> GetActiveCartByUserId(int userId)
        {
            return await _context.Carts
                .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsCheckedOut);
        }

        public async Task<Cart> GetCartByCartId(int cartId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(u => u.CartId == cartId);
            if (cart == null)
            {
                throw new NotFoundException("Cart not found");
            }
            return cart;
        }
    }
}
