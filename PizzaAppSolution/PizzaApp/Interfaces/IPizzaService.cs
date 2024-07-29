using PizzaApp.Models;

namespace PizzaApp.Interfaces
{
    public interface IPizzaService
    {
        Task<IEnumerable<Pizza>> GetAllPizzas();
        Task<IEnumerable<Pizza>> GetAllBestSellerPizzas();
        Task<IEnumerable<Pizza>> GetAllNewPizzas();
        Task<IEnumerable<Pizza>> GetAllVegPizzas();
        Task<IEnumerable<Pizza>> GetAllNonVegPizzas();

    }
}
