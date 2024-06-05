using Models;

namespace Repositories
{
    public interface IGaragemRepository
    {
        List<Carro> GetCarrosVermelhos();
        List<Carro> GetCarros2010a2011();
        List<Carro> GetStatusTrue();

    }
}
