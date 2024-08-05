using Microsoft.EntityFrameworkCore;
using PizzaApp.Exceptions;
using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Models.DTOs;
using PizzaApp.Models.Enums;
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
        public async Task<int> AddOrder(OrderInputDTO orderInputDTO)
        {
            var order = new Order
            {
                PaymentId = orderInputDTO.PaymentId,
                CartId = orderInputDTO.CartId,
                UserId = (int)orderInputDTO.UserId,
                OrderDate = DateTime.Now,
                Status = OrderStatus.OrderPlaced,
                Address=orderInputDTO.Address,
                Phone=orderInputDTO.Phone
                
            };
            await _orderRepository.Add(order);
            return order.OrderId;
        }

        public async Task<IEnumerable<OrderGetDTO>> GetAllOrders()
        {
            var orders = await _orderRepository.Get();
            if (!orders.Any())
            {
                throw new EmptyException("No cart items found");
            }
            var orderDTOs = orders.Select(order => new OrderGetDTO
            {
                CartId = order.CartId,
                UserId = order.UserId, OrderDate=order.OrderDate,
                OrderId = order.OrderId,
                PaymentId =order.PaymentId,
                Status=order.Status, 
                Phone=order.Phone,
                Address=order.Address
               
                
            });

            return orderDTOs;
        }

        public async Task<OrderGetDTO> GetOrderById(int OrderId)
        {
            var order = await _orderRepository.GetOrderById(OrderId);

            var ordergetDTO = new OrderGetDTO
            {  
                OrderId=order.OrderId,
                CartId = order.CartId,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                PaymentId = order.PaymentId,
                Status = order.Status,Address=order.Address,
                Phone=order.Phone
                
                


            };

            return ordergetDTO;
        }

        public async Task<IEnumerable<OrderGetDTO>> GetOrdersByUserId(int userId)
        {
            var orders = await GetAllOrders();
            var filteredOrders = orders.Where(order => order.UserId == userId);

            if (!filteredOrders.Any())
            {
                throw new EmptyException("No cart items found for the specified user");
            }

            return filteredOrders;
        }

        public async Task<int> UpdateOrderStatus(OrderUpdateDTO orderUpdateDTO)
        {
            var order = await _orderRepository.GetOrderById(orderUpdateDTO.OrderId);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {orderUpdateDTO.OrderId} not found.");
            }

            // Update the order status
            order.Status = orderUpdateDTO.Status;

            // Save changes
            await _orderRepository.Update(order);

     
           

            return order.OrderId;
        }
    }
 }

