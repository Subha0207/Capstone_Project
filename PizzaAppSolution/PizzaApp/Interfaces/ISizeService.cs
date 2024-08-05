using PizzaApp.Models;
using PizzaApp.Models.DTOs;

namespace PizzaApp.Interfaces
{
    public interface ISizeService
    {
        Task<IEnumerable<Size>> GetAllSizes();
        public Task<Size> GetSizeById(int SizeId);
        Task<IEnumerable<SizeDTO>> GetAllSizePriceBySizeId(int PizzaId);
        public  Task<int> GetCostBySizeIdAndPizzaId(int pizzaId, int sizeId);
    }
}
