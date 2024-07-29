using PizzaApp.Models;

namespace PizzaApp.Interfaces
{
    public interface ICrustService
    {
        Task<IEnumerable<Crust>> GetAllCrusts();
    }
}
