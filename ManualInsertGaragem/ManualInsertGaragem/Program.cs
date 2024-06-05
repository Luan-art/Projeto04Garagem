using System.Text;
using System.Xml.Linq;
using System.Xml;
using Models;
using Controllers;

Console.WriteLine("Inicio...");

int op = 0;

while (true)
{
    Console.WriteLine("Digite se deseja Inserir Servico ou CarroServico ( 1 ou 2 ) respectivamente");
    op = int.Parse(Console.ReadLine());

    switch (op)
    {
        case 1:
            AdcionarServico();
            break;
        case 2:
            AdcionarCarroServico();
            break;
        default:
            Console.WriteLine("Invalido");
            break;
    }
}

void AdcionarCarroServico()
{
    CarroServico carroServico = new CarroServico();

    Console.WriteLine("Digite a placa do carro");

    carroServico.Carro = GetCarro(Console.ReadLine());

    Console.WriteLine("Digite o id do Servico");

    carroServico.Servico = GetServico(int.Parse(Console.ReadLine()));

    Console.WriteLine("Digite se o status está ativo (1 - sim e 2 - não)");

    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            carroServico.Status = true;
            break;
        case 2:
            carroServico.Status = false;
            break;
        default:
            Console.WriteLine("Invalid");
            break;
    }


    if (new GaragemController().InserirCarroServico(carroServico))
    {
        Console.WriteLine("Inserido");
    }
    else
    {
        Console.WriteLine("Erro");
    }

}

Servico GetServico(int v)
{
    Servico servico = new GaragemController().GetServico(v);

    return servico;
}

Carro GetCarro(string? v)
{
    Carro carro = new GaragemController().GetCarro(v);

    return carro;

}

void AdcionarServico()
{
    Servico servico = new Servico();

    Console.WriteLine("Digite a descrição");
    servico.Descricao = Console.ReadLine();

    if (new GaragemController().InserirServico(servico))
    {
        Console.WriteLine("Inserido");
    }
    else
    {
        Console.WriteLine("Erro");
    }

}