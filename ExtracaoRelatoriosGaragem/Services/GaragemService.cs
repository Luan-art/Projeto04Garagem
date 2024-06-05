using Microsoft.Data.SqlClient;
using Models;
using Repositories;

namespace Services
{
    public class GaragemService
    {
        private IGaragemRepository iGaragemRepository;

        public GaragemService()
        {
            iGaragemRepository = new SqlRepository();
        }

        public List<Carro> GetCarros2010a2011() => iGaragemRepository.GetCarros2010a2011();

        public List<Carro> GetCarrosVermelhos() => iGaragemRepository.GetCarrosVermelhos();

        public List<Carro> GetStatusTrue() => iGaragemRepository.GetStatusTrue();
        
    }
}
