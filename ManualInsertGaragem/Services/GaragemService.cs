using Models;
using Repositories;

namespace Services
{
    public class GaragemService
    {
        private IGaragemRepository iGaragemRepository;

        public GaragemService()
        {
            iGaragemRepository = new SQLRepository();
        }

        public bool InserirServico(Servico servico)
        {
            if (iGaragemRepository.InserirServico(servico))
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
            if (iGaragemRepository.InserirCarroServico(cS))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Servico GetService(int v) => iGaragemRepository.GetService(v);

        public Carro GetCarro(string? v) => iGaragemRepository.GetCarro(v);
    }
}
