using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Exceptions;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>
    {
        private readonly PizzaAppContext _context;


        public PaymentRepository(PizzaAppContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Payment> GetPaymentById(int paymentId)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(u => u.PaymentId == paymentId);
            if (payment == null)
            {
                throw new NotFoundException("payment not found");
            }
            return payment;
        }
    }
}
