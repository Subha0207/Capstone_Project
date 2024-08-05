using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Exceptions;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        private readonly PizzaAppContext _context;


        public OrderRepository(PizzaAppContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Order> GetOrderById(int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(u => u.OrderId == orderId);
            if (order == null)
            {
                throw new NotFoundException("order not found");
            }
            return order;
        }
    }
}
