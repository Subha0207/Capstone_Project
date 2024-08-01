using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Interfaces
{
    public interface IBeverageService
    {
        Task<IEnumerable<Beverage>> GetAllBeverages();

        Task<IEnumerable<Beverage>> GetAllNewBeverages();
        Task<IEnumerable<Beverage>> GetAllBestSellingBeverages();
        public Task<Beverage> GetBeverageByBeverageId(int BeverageId);

    }
}
