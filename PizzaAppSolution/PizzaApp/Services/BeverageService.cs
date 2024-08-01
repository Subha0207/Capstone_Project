using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Repositories;

namespace PizzaApp.Services
{
    public class BeverageService : IBeverageService
    {

        private readonly BeverageRepository _beverageRepository;

        public BeverageService(BeverageRepository beverageRepository)
        {
            _beverageRepository = beverageRepository;
        }

        public async Task<IEnumerable<Beverage>> GetAllBestSellingBeverages()
        {

            var beverages = await _beverageRepository.Get();
            return beverages.Where(p => p.IsBestSeller);
        }

        public async Task<IEnumerable<Beverage>> GetAllBeverages()
        {
            return await _beverageRepository.Get();
        }

        public async Task<IEnumerable<Beverage>> GetAllNewBeverages()
        {
            var beverages = await _beverageRepository.Get();
            var oneWeekAgo = DateTime.UtcNow.AddDays(-7);
            return beverages.Where(p => p.UploadDate >= oneWeekAgo);
        }
        public async Task<Beverage> GetBeverageByBeverageId(int beverageId)
        {
            var beverage = await _beverageRepository.GetBeverageByBeverageId(beverageId);
            if (beverage == null)
            {
                throw new Exception("Beverage not found");
            }
            return beverage;
        }

    }
}
