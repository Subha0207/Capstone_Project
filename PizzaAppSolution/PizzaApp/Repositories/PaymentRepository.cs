using PizzaApp.Contexts;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>
    {
        public PaymentRepository(PizzaAppContext context) : base(context)
        {
        }
    }
}
