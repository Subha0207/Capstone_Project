using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Repositories;

namespace PizzaApp.Services
{
    public class ToppingService : IToppingService
    {
        private readonly ToppingRepository _toppingRepository;

        public ToppingService(ToppingRepository toppingRepository)
        {
            _toppingRepository = toppingRepository;
        }

        public async Task<IEnumerable<Topping>> GetAllToppings()
        {
            return await _toppingRepository.Get();
        }

        public async Task<Topping> GetToppingById(int ToppingId)
        {
            var topping = await _toppingRepository.GetToppingByToppingId(ToppingId);
            if (topping == null)
            {
                throw new Exception("Topping not found");
            }
            return topping;
        }
    }
}
