using PizzaApp.Models;
using PizzaApp.Models.DTOs;

namespace PizzaApp.Interfaces
{
    public interface ICrustService
    {
        Task<IEnumerable<Crust>> GetAllCrusts();
        public Task<Crust> GetCrustById(int CrustId);
        public  Task<decimal> GetSizeCostById(int pizzaId, int selectedSizeId);
       // public  Task<IEnumerable<CrustDTO>> GetAllCrustPriceByPizzaIdWithSize(int pizzaId, int selectedSizeId);
    }
}
