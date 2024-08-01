using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Repositories;

namespace PizzaApp.Services
{
    public class OrderService : IOrderService
    {

        private readonly CartRepository _cartRepository;
        private readonly OrderRepository _orderRepository;
        private readonly UserRepository _userRepository;
        private readonly PaymentRepository _paymentRepository;

        public OrderService(OrderRepository orderRepository,PaymentRepository paymentRepository, UserRepository userRepository,CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;

            _paymentRepository = paymentRepository;

        }
        public Task<OrderDTO> AddOrder(OrderInputDTO orderInputDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> GetOrderById(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDTO>> GetOrdersByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> UpdateOrderStatus(OrderUpdateDTO orderUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
