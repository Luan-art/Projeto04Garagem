namespace Models
{
    public class Carro
    {
        public string Placa { get; set; }
        public string Nome { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string Cor { get; set; }

        public Carro()
        {

        }

        public override string? ToString()
        {
            return $"Placa: {Placa}\nNome: {Nome}\nAno/Modelo: {AnoModelo} - Ano Fabricação: {AnoFabricacao}\nCor: {Cor}";
        }
    }
}