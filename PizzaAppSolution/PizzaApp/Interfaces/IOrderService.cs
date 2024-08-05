using PizzaApp.Models;
using PizzaApp.Models.DTOs;

namespace PizzaApp.Interfaces
{
    public interface IOrderService
    {
        public Task<int> AddOrder(OrderInputDTO orderInputDTO);

        public Task<OrderGetDTO> GetOrderById(int OrderId);
        Task<IEnumerable<OrderGetDTO>> GetAllOrders();

        Task<IEnumerable<OrderGetDTO>> GetOrdersByUserId(int userId);

        public Task<int> UpdateOrderStatus(OrderUpdateDTO orderUpdateDTO) ;
    }
}
