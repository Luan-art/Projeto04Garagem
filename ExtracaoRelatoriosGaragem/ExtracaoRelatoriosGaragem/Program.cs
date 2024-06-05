using System.Text;
using System.Xml.Linq;
using System.Xml;
using Models;
using Controllers;

Console.WriteLine("Inicio...");

int op = 0;
List<Carro> carros = new List<Carro>();
List<CarroServico> carrosServicos = new List<CarroServico>();   


while (true)
{
    Console.WriteLine("Digite se deseja retornar carros com servicos ativos, carros vermelhos ou carros entre 2010 e 2011 ( 1, 2 e 3 ) respectivamente");
    op = int.Parse(Console.ReadLine());

    switch (op)
    {
        case 1:
            GerarXMLCarro(new GaragemController().GetStatusTrue());
            break;
        case 2:
            GerarXMLCarro(new GaragemController().GetCarrosVermelhos());
            break;
        case 3:
            GerarXMLCarro(new GaragemController().GetCarros2010a2011());
            break;
        default:       
            Console.WriteLine("Invalido");
            break;
    }
}

void GerarXMLCarro(List<Carro> Carro)
{
    if (Carro.Count > 0)
    {
        var penalidadeAplicada = new XElement("Root", from data in Carro
                                                      select new XElement("Carro",
                                                          new XElement("Placa", data.Placa),
                                                          new XElement("Nome", data.Nome),
                                                          new XElement("AnoModelo", data.AnoModelo),
                                                          new XElement("AnoFabricacao", data.AnoFabricacao),
                                                          new XElement("Cor", data.Cor)));

        Console.WriteLine(penalidadeAplicada.ToString());
    }

}



