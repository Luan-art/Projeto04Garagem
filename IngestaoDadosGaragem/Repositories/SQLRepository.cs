using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace Repositories
{
    public class SQLRepository : IGaragemRepository
    {
        public bool Inserir(List<Carro> carros)
        {
            string strConn = "Data Source=127.0.0.1; Initial Catalog=DBGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";
            bool result = false;
            string sql = "INSERT INTO CARRO (Placa, Nome, AnoModelo, AnoFabricacao, Cor) VALUES (@Placa, @Nome, @AnoModelo, @AnoFabricacao, @Cor)";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    foreach(Carro carro in carros)
                    {
                        db.Execute(sql, carro);

                    }
                }

                result = true;

            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }
    }
}
