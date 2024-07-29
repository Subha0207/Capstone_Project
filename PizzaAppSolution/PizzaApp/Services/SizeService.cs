using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Repositories;

namespace PizzaApp.Services
{
    public class SizeService : ISizeService
    {
        private readonly SizeRepository _sizeRepository;

        public SizeService(SizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<IEnumerable<Size>> GetAllSizes()
        {
            return await _sizeRepository.Get();
        }


    }
}
