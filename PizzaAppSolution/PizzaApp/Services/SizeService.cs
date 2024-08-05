using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Models.DTOs;
using PizzaApp.Repositories;

namespace PizzaApp.Services
{
    public class SizeService : ISizeService
    {
        private readonly SizeRepository _sizeRepository;
        private readonly PizzaRepository _pizzaRepository;

        public SizeService(SizeRepository sizeRepository,PizzaRepository pizzaRepository)
        {
            _sizeRepository = sizeRepository;
            _pizzaRepository = pizzaRepository;
        }

        public async Task<IEnumerable<SizeDTO>> GetAllSizePriceBySizeId(int PizzaId)
        {
            var pizza = await _pizzaRepository.GetPizzaByPizzaId(PizzaId);
            var baseCost = pizza.Cost;


            var sizes = await _sizeRepository.Get();


            var sizeDTOs = new List<SizeDTO>();


            foreach (var size in sizes)
            {

                var sizeDTO = new SizeDTO
                {
                    SizeId=size.SizeId,
                    Name = size.Name,
                    Cost = baseCost * size.SizeMultiplier
                };

                // Add the CrustDTO to the list
                sizeDTOs.Add(sizeDTO);
            }

            // Return the list of CrustDTOs
            return sizeDTOs;

        }

        public async Task<IEnumerable<Size>> GetAllSizes()
        {
            return await _sizeRepository.Get();
        }

        public async Task<Size> GetSizeById(int SizeId)
        {
            var size = await _sizeRepository.GetSizeBySizeId(SizeId);
            if (size == null)
            {
                throw new Exception("Size not found");
            }
            return size;
        }

        public async Task<int> GetCostBySizeIdAndPizzaId(int pizzaId, int sizeId)
        {
            var pizza = await _pizzaRepository.GetPizzaByPizzaId(pizzaId);
            var baseCost = pizza.Cost;

            var size = await _sizeRepository.GetSizeBySizeId(sizeId);
            if (size == null)
            {
                throw new Exception("Size not found");
            }
        
            var sizeDTO = new SizeDTO
            {
                Name = size.Name,
                Cost = baseCost * size.SizeMultiplier
            };

            return (int)sizeDTO.Cost;
        }
 }
}
