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

        public bool Inserir()
        {
            return garagemService.Inserir();
        }
    }
}
