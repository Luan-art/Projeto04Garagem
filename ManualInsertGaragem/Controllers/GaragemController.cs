using Models;
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

        public bool InserirServico(Servico servico)
        {
            if (garagemService.InserirServico(servico))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool InserirCarroServico(CarroServico cS)
        {
            if (garagemService.InserirCarroServico(cS))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Servico GetServico(int v) => garagemService.GetService(v);

        public Carro GetCarro(string? v) => garagemService.GetCarro(v);

    }
}
