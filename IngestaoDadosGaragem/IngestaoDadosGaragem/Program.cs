using Controllers;

Console.WriteLine("Inicio...");

if (new GaragemController().Inserir())
{
    Console.WriteLine("Inseriu tudo!!!!");
}
else
{
    Console.WriteLine("ERRO");
}