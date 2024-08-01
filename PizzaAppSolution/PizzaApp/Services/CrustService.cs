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

        public CrustService(CrustRepository crustRepository, PizzaRepository pizzaRepository)
        {
            _crustRepository = crustRepository;
            _pizzaRepository = pizzaRepository;
        }

        public async Task<IEnumerable<CrustDTO>> GetAllCrustPriceByPizzaId(int PizzaId)
        {
           
            var pizza = await _pizzaRepository.GetPizzaByPizzaId(PizzaId);
            var baseCost = pizza.Cost;

           
            var crusts = await _crustRepository.Get();

           
            var crustDTOs = new List<CrustDTO>();

           
            foreach (var crust in crusts)
            {
              
                var crustDTO = new CrustDTO
                {
                  
                    Name = crust.Name,
                    Cost = baseCost * crust.CrustMultiplier 
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
