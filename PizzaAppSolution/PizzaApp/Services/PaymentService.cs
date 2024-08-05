using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Models.DTOs;
using PizzaApp.Repositories;

namespace PizzaApp.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly CartRepository _cartRepository;

        private readonly UserRepository _userRepository;
        private readonly PaymentRepository _paymentRepository;

        public PaymentService(PaymentRepository paymentRepository, UserRepository userRepository, CartRepository cartRepository)
        {
            _cartRepository = cartRepository;

            _userRepository = userRepository;

            _paymentRepository = paymentRepository;

        }
        public async Task<int> AddPayment(PaymentInputDTO paymentInputDTO)
        {
            var cart = await _cartRepository.GetCartByCartId(paymentInputDTO.CartId);

            var payment = new Payment
            {
                UserId = paymentInputDTO.UserId,
                PaymentDate= DateTime.UtcNow,
                Amount = (decimal)cart.TotalPrice,
                Method=paymentInputDTO.Method,
                CartId = cart.CartId,
                
            };

            await _paymentRepository.Add(payment);

         
            return payment.PaymentId;
        }

        public async Task<decimal> GetAmountByPaymentId(int PaymentId)
        {
            var payment = await _paymentRepository.GetPaymentById(PaymentId);

            var payment1 = new Payment
            {
                CartId = payment.CartId,
                UserId = payment.UserId,
               Amount=payment.Amount,
                PaymentId = payment.PaymentId,
               



            };

            return payment1.Amount;
        }

        public async Task<PaymentDTO> GetDetailsByPaymentId(int PaymentId)
        {
            var payment = await _paymentRepository.GetPaymentById(PaymentId);

            var payment1 = new PaymentDTO
            {
                CartId = payment.CartId,
                UserId = payment.UserId,
                Amount = payment.Amount,
                PaymentId = payment.PaymentId,
                Method = payment.Method,
                PaymentDate=payment.PaymentDate



            };

            return payment1;
        }
    }
}
