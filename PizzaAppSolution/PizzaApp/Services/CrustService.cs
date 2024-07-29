using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Services
{
    public class CrustService : ICrustService
    {
        private readonly CrustRepository _crustRepository;

        public CrustService(CrustRepository crustRepository)
        {
            _crustRepository = crustRepository;
        }

        public async Task<IEnumerable<Crust>> GetAllCrusts()
        {
            return await _crustRepository.Get();
        }


    }
}
