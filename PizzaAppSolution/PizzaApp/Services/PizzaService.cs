using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Repositories;

namespace PizzaApp.Services
{
    public class PizzaService:IPizzaService
    {

        private readonly PizzaRepository _pizzaRepository;

        public PizzaService(PizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
        public async Task<IEnumerable<Pizza>> GetAllBestSellerPizzas()
        {
            var pizzas = await _pizzaRepository.Get();
            return pizzas.Where(p => p.IsBestSeller);
        }
        public async Task<IEnumerable<Pizza>> GetAllVegPizzas()
        {
            var pizzas = await _pizzaRepository.Get();
            return pizzas.Where(p => p.IsVeg);
        }
        public async Task<IEnumerable<Pizza>> GetAllNonVegPizzas()
        {
            var pizzas = await _pizzaRepository.Get();
            return pizzas.Where(p => !p.IsVeg);
        }
        public async Task<IEnumerable<Pizza>> GetAllNewPizzas()
        {
            var pizzas = await _pizzaRepository.Get();
            var oneWeekAgo = DateTime.UtcNow.AddDays(-7);
            return pizzas.Where(p => p.UploadDate >= oneWeekAgo);
        }

        public async Task<IEnumerable<Pizza>> GetAllPizzas()
        {
            return await _pizzaRepository.Get();
        }

    }
}
