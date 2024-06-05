using Models;

namespace Repositories
{
    public interface IGaragemRepository
    {
        bool InserirServico(Servico servico);
        bool InserirCarroServico(CarroServico carroServico);
        Carro GetCarro(string? v);
        Servico GetService(int v);
    }
}
