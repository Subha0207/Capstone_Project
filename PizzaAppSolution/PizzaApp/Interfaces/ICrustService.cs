using PizzaApp.Models;
using PizzaApp.Models.DTOs;

namespace PizzaApp.Interfaces
{
    public interface ICrustService
    {
        Task<IEnumerable<Crust>> GetAllCrusts();
        public Task<Crust> GetCrustById(int CrustId);
        public Task<IEnumerable<CrustDTO>> GetAllCrustPriceBySizeId(int PizzaId, int SizeId);


    }
}
