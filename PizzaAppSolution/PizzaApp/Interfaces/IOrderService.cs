using PizzaApp.Models;
using PizzaApp.Models.DTOs;

namespace PizzaApp.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderDTO> AddOrder(OrderInputDTO orderInputDTO);

        public Task<OrderDTO> GetOrderById(int OrderId);
        Task<IEnumerable<OrderDTO>> GetAllOrders();

        Task<IEnumerable<OrderDTO>> GetOrdersByUserId(int userId);

        public Task<OrderDTO> UpdateOrderStatus(OrderUpdateDTO orderUpdateDTO) ;
    }
}
