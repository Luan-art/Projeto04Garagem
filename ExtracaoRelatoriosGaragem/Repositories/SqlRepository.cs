using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SqlRepository : IGaragemRepository
    {
        public List<Carro> GetCarros2010a2011()
        {
            string strConn = "Data Source=127.0.0.1; Initial Catalog=DBGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

            using (var connection = new SqlConnection(strConn))
            {
                connection.Open();

                try
                {
                    var carros = connection.Query<Carro>("SELECT Placa, nome, AnoModelo, Cor FROM CARRO WHERE AnoModelo BETWEEN @anoInicio AND @anoFim", new { anoInicio = 2010, anoFim = 2011 }).ToList();

                    return carros;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Carro> GetCarrosVermelhos()
        {
            string strConn = "Data Source=127.0.0.1; Initial Catalog=DBGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

            using (var connection = new SqlConnection(strConn))
            {
                connection.Open();

                try
                {
                    var carros = connection.Query<Carro>("SELECT Placa, nome, AnoModelo, Cor FROM CARRO WHERE cor = @cor", new { cor = "vermelho" }).ToList();

                    return carros;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Carro> GetStatusTrue()
        {
            string strConn = "Data Source=127.0.0.1; Initial Catalog=DBGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

            using (var connection = new SqlConnection(strConn))
            {
                connection.Open();

                try
                {
                    var carro = connection.Query<Carro>("SELECT c.Placa, c.Nome, c.AnoModelo, c.AnoFabricacao, c.Cor FROM CARRO c INNER JOIN CARRO_SERVICO cs ON c.Placa = cs.Carro WHERE cs.Status = @Status", new { Status = 1 }).ToList();

                    return carro;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            } 

        }
    }
}
