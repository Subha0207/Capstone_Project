using PizzaApp.Models;
using PizzaApp.Models.DTOs;
using PizzaApp.Repositories;

namespace PizzaApp.Interfaces
{
    public interface IPaymentService
    {

  
        public Task<int> AddPayment(PaymentInputDTO paymentInputDTO);

        public  Task<decimal> GetAmountByPaymentId(int PaymentId);
        public Task<PaymentDTO> GetDetailsByPaymentId(int PaymentId);

    }
}
