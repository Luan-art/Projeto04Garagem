using Models;
using Newtonsoft.Json;
using Repositories;
using System.Diagnostics;
using System.Globalization;

namespace Services
{
    public class GaragemService
    {
        private IGaragemRepository iGaragemRepository;
        string caminhoJson = "C:\\Users\\LuanLF\\source\\repos\\Projeto04\\Garagem.json";
        public GaragemService()
        {
            iGaragemRepository = new SQLRepository();
        }

        public bool Inserir()
        {

            try
            {
                var carros = GetData(caminhoJson);

                iGaragemRepository.Inserir(carros);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public static List<Carro>? GetData(string path)
        {

            StreamReader sr = new(path);
            string jsonString = sr.ReadToEnd();

            var settings = new JsonSerializerSettings
            {
                Culture = new CultureInfo("pt-BR"),
                DateFormatString = "dd/MM/yyyy"
            };

            List<Carro> list = JsonConvert.DeserializeObject<List<Carro>>(jsonString, settings);

            if (list != null) return list;
            return null;
        }

    }

    public class ListaCarros
    {
        [JsonProperty("carro")]
        public List<Carro>? ListaDeCarros { get; set; }
    }


}
