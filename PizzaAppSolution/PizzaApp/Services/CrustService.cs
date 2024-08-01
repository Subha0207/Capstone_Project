using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Models.DTOs;
using PizzaApp.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Services
{
    public class CrustService : ICrustService
    {
        private readonly CrustRepository _crustRepository;
        private readonly PizzaRepository _pizzaRepository;
        private readonly SizeService _sizeService;
        private readonly SizeRepository _sizeRepository;

        public CrustService(CrustRepository crustRepository, PizzaRepository pizzaRepository,SizeRepository sizeRepository,SizeService sizeService
            )
        {
            _crustRepository = crustRepository;
            _pizzaRepository = pizzaRepository;
            _sizeService = sizeService;
            _sizeRepository = sizeRepository;
        }

        public async Task<IEnumerable<CrustDTO>> GetAllCrustPriceByPizzaIdWithSize(int pizzaId, int selectedSizeId)
        {
            // Get the cost of the selected size
            var sizeCost = await GetSizeCostById(pizzaId, selectedSizeId);

            if (sizeCost == 0)
            {
                // Handle the case where the selected size is not found
                return Enumerable.Empty<CrustDTO>();
            }

            // Fetch all crusts
            var crusts = await _crustRepository.Get();

            var crustDTOs = new List<CrustDTO>();

            foreach (var crust in crusts)
            {
                var crustDTO = new CrustDTO
                {
                    Name = crust.Name,
                    Cost = sizeCost * crust.CrustMultiplier
                };

                crustDTOs.Add(crustDTO);
            }

            return crustDTOs;
        }


        public async Task<decimal> GetSizeCostById(int pizzaId, int selectedSizeId)
        {
            // Fetch all size prices for the given pizzaId
            var sizeDTOs = await _sizeService.GetAllSizePriceBySizeId(pizzaId);

            // Find the size with the matching SizeId
            var selectedSize = sizeDTOs.FirstOrDefault(size => size.SizeId == selectedSizeId);

            // Return the cost if the selected size is found, otherwise return 0
            return selectedSize != null ? selectedSize.Cost : 0;
        }


        public async Task<IEnumerable<Crust>> GetAllCrusts()
        {
            return await _crustRepository.Get();
        }

        public async Task<Crust> GetCrustById(int CrustId)
        {
            var crust = await _crustRepository.GetCrustByCrustId(CrustId);
            if (crust == null)
            {
                throw new Exception("Crust not found");
            }
            return crust;
        }
    }
}
