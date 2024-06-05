using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SQLRepository : IGaragemRepository
    {
        public Carro GetCarro(string? v)
        {
            string strConn = "Data Source=127.0.0.1; Initial Catalog=DBGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

            using (var connection = new SqlConnection(strConn))
            {
                connection.Open();

                try
                {
                    var carro = connection.QueryFirstOrDefault<Carro>("SELECT Placa, nome, AnoModelo, Cor FROM CARRO WHERE Placa = @Placa", 
                        new { Placa = v});

                    Console.WriteLine(carro);

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

        public Servico? GetService(int v)
        {
            string strConn = "Data Source=127.0.0.1; Initial Catalog=DBGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

            using (var connection = new SqlConnection(strConn))
            {
                connection.Open();

                try
                {
                    var servico = connection.QueryFirstOrDefault<Servico>("SELECT Id, Descricao FROM SERVICO WHERE Id = @id",
                        new { id = v });

                    Console.WriteLine(servico);
                    return servico;
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

        public bool InserirCarroServico(CarroServico carroServico)
        {
            string strConn = "Data Source=127.0.0.1; Initial Catalog=DBGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";
            bool result = false;
            string sql = "INSERT INTO CARRO_SERVICO (Carro, Servico, Status) VALUES (@Carro, @Servico, @Status)";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, new { Carro = carroServico.Carro.Placa, Servico = carroServico.Servico.Id, Status = carroServico.Status});

                }

                result = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }

        public bool InserirServico(Servico servico)
        {
            string strConn = "Data Source=127.0.0.1; Initial Catalog=DBGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";
            bool result = false;
            string sql = "INSERT INTO SERVICO (Descricao) VALUES (@Descricao)";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, servico);

                }

                result = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }
    }

}

