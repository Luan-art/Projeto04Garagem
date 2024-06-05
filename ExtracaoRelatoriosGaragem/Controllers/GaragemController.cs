using Models;
using Repositories;
using Services;

namespace Controllers
{
    public class GaragemController
    {
        private GaragemService garagemService;
        public GaragemController()
        {
            garagemService = new GaragemService();
        }

        public List<Carro> GetCarros2010a2011() => garagemService.GetCarros2010a2011();

        public List<Carro> GetCarrosVermelhos() => garagemService.GetCarrosVermelhos();

        public List<Carro> GetStatusTrue() => garagemService.GetStatusTrue();
    }
}
