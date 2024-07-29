using PizzaApp.Models;

namespace PizzaApp.Interfaces
{
    public interface ISizeService
    {
        Task<IEnumerable<Size>> GetAllSizes();
    }
}
