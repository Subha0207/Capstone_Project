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

        public async Task<IEnumerable<CrustDTO>> GetAllCrustPriceBySizeId(int PizzaId, int SizeId)
        {
            var pizza = await _pizzaRepository.GetPizzaByPizzaId(PizzaId);
          


            var crusts = await _crustRepository.Get();


            var crustDTOs = new List<CrustDTO>();
            var updatedCost = await _sizeService.GetCostBySizeIdAndPizzaId(PizzaId,SizeId);


            foreach (var crust in crusts)
            {

                var crustDTO = new CrustDTO
                {
                    CrustId=crust.CrustId,
                    Name = crust.Name,
                    Cost = updatedCost * crust.CrustMultiplier
                };

                // Add the CrustDTO to the list
                crustDTOs.Add(crustDTO);
            }

            // Return the list of CrustDTOs
            return crustDTOs;

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
