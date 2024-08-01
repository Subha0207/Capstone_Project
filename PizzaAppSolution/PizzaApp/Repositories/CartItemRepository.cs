using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Exceptions;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class CartItemRepository : BaseRepository<CartItem>
    {
        private readonly PizzaAppContext _context;

        public CartItemRepository(PizzaAppContext context) : base(context)
        {
            _context = context;
        }
        public async Task<CartItem> GetCartItemByCartItemId(int cartItemId)
        {
            var cartItem = await _context.CartItem.FirstOrDefaultAsync(u => u.CartItemId == cartItemId);
            if (cartItem == null)
            {
                throw new NotFoundException("cartItem not found");
            }
            return cartItem;
        }
        public async Task<IEnumerable<CartItem>> GetCartItemsByCartId(int cartId)
        {
            // Replace with your actual data fetching logic, e.g., using Entity Framework
            return await _context.CartItem.Where(ci => ci.CartId == cartId).ToListAsync();
        }
        public async Task<CartItem> DeleteByCartItemId(int key)
        {
            try
            {

                var cartItem = await Get(key);
                if (cartItem == null)
                {
                    throw new NotFoundException("No such cartItem exists.");
                }

                _context.Remove(cartItem);

                await _context.SaveChangesAsync(true);
                return cartItem;
            }
            catch (NotFoundException ex)
            {

                throw;
            }
            catch (Exception ex)
            {

                throw new Exception("Error while deleting flight.", ex);
            }
        }
    }
}
