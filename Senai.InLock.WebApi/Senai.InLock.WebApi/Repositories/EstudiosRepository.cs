using Senai.InLock.WebApi.Domain;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudiosRepository : Iestudios
    {
        private string StringConexao = "Data Source = DEV2\\SQLEXPRESS; initial catalog = T_InLock_Games_Tarde; user Id = sa; pwd=sa@132";

        public List<EstudiosDomain> Listar()
        {
            List<EstudiosDomain> estudios = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT Estudios.IdEstudio,Estudios.NomeEstudio,NomeJogo FROM Jogos RIGHT OUTER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudiosDomain estudiosDomain = new EstudiosDomain

                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            NomeEstudio = rdr["NomeEstudio"].ToString(),

                             jogos = new JogosDomain
                            {
                                NomeJogo = rdr["NomeJogo"].ToString(),
                            }
                          };
                        

                        estudios.Add(estudiosDomain);
                    }
                }
            }

            return estudios;
        }
        public void AdicionarEstudio(EstudiosDomain estudios)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Estudios(NomeEstudio) VALUES (@nome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nome", estudios.NomeEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdCorpo(EstudiosDomain estudios)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryAtuaulizarIdCorpo = "UPDATE Estudios SET Titulo = @Nome WHERE IdEstudio = @ID; ";


                using (SqlCommand cmd = new SqlCommand(queryAtuaulizarIdCorpo, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Nome", estudios.NomeEstudio);

                    cmd.Parameters.AddWithValue("@ID", estudios.IdEstudio);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public EstudiosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT IdEstudio, NomeEstudio FROM Estudios WHERE IdEstudio = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        EstudiosDomain estudios = new EstudiosDomain
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        return estudios;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Estudios WHERE IdEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
