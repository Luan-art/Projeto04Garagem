using Models;
using Newtonsoft.Json;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

List<Carro> carros = new List<Carro>();

for (int i = 0; i < 30; i++)
{
    carros.Add(GerarCarro());

}

ManipularCarros(carros);

string GerarCor()
{
    string[] cores = {
            "Preto",
            "Branco",
            "Cinza",
            "Prata",
            "Vermelho",
            "Azul",
            "Verde",
            "Amarelo",
            "Roxo",
            "Marrom"
    };
    return cores[new Random().Next(0, cores.Length)];
}

string GerarNome()
{
    string[] nomes = new string[]
    {
            "Ford Mustang",
            "Chevrolet Camaro",
            "Dodge Charger",
            "Toyota Corolla",
            "Honda Civic",
            "BMW 3 Series",
            "Audi A4",
            "Mercedes-Benz C-Class",
            "Volkswagen Golf",
            "Nissan Altima",
            "Hyundai Elantra",
            "Kia Optima",
            "Subaru Impreza",
            "Mazda 3",
            "Tesla Model 3",
            "Lexus IS",
            "Jaguar XE",
            "Infiniti Q50",
            "Acura TLX",
            "Cadillac ATS",
            "Alfa Romeo Giulia",
            "Volvo S60",
            "Mitsubishi Lancer",
            "Mini Cooper",
            "Porsche 911",
            "Ferrari 488",
            "Lamborghini Huracan",
            "McLaren 720S",
            "Aston Martin Vantage",
            "Rolls-Royce Phantom"
    };

    return nomes[new Random().Next(0, nomes.Length)];
}

string GerarPlaca()
{
    string placa = "";
    string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    placa += letras[new Random().Next(0, letras.Length)];
    placa += letras[new Random().Next(0, letras.Length)];
    placa += letras[new Random().Next(0, letras.Length)];
    placa += new Random().Next(0, 10).ToString();
    placa += letras[new Random().Next(0, letras.Length)];
    placa += new Random().Next(0, 10).ToString();
    placa += new Random().Next(0, 10).ToString();

    return placa;
}

Carro GerarCarro()
{
    int anoModelo = new Random().Next(1990, DateTime.Now.Year + 2);
    int anoFabricacao = new Random().Next(anoModelo - 1, DateTime.Now.Year);

    Carro carro = new Carro
    {
        Placa = GerarPlaca(),
        Nome = GerarNome(),
        AnoModelo = anoModelo,
        AnoFabricacao = anoFabricacao,
        Cor = GerarCor(),
    };
    return carro;
}

void ManipularCarros(List<Carro> carros)
{

    string path = @"C:\Users\LuanLF\source\repos\Projeto04"; 
    string file = @"Garagem.json";

    VerificarCaminhos(path, file);

    StreamWriter sw = new(path + file);

    sw.WriteLine(JsonConvert.SerializeObject(carros, Formatting.Indented));

    sw.Close();
}

void VerificarCaminhos(string path, string file)
{
    if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
    if (!File.Exists(Path.Combine(path, file)))
    {
        var aux = File.Create(Path.Combine(path, file));
        aux.Close();
    }
}