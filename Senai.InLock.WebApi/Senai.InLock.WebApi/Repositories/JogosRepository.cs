using Senai.InLock.WebApi.Domain;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogosRepository : Ijogos
    {
        private string StringConexao = "Data Source=DEV2\\SQLEXPRESS; initial catalog=T_InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        public List<JogosDomain> Listar()
        {
            List<JogosDomain> jogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdJogo,NomeJogo,Descricao,DataLancamento,Valor,Jogos.IdEstudio,Estudios.IdEstudio,NomeEstudio FROM Jogos INNER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogos1 = new JogosDomain
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),
                            NomeJogo = rdr["NomeJogo"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr[3]),
                            Valor = Convert.ToInt32(rdr[4]),
                            IdEstudio = Convert.ToInt32(rdr[5]),
                            EstudiosDomain = new EstudiosDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                NomeEstudio = rdr["NomeEstudio"].ToString()
                            }
                        };
                        jogos.Add(jogos1);
                    }
                }
            }
            return jogos;
        }
        public void AdicionarJogo(JogosDomain jogos)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Jogos(NomeJogo,Descricao,DataLancamento,Valor,IdEstudio) VALUES(@Nome,@descricao,@dataLancamento,@valor,@idEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", jogos.NomeJogo);

                    cmd.Parameters.AddWithValue("@descricao", jogos.Descricao);

                    cmd.Parameters.AddWithValue("@dataLancamento", jogos.DataLancamento);

                    cmd.Parameters.AddWithValue("@valor", jogos.Valor);

                    cmd.Parameters.AddWithValue("idEstudio", jogos.IdEstudio);



                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void AtualizarIdCorpo(JogosDomain jogos)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryAtuaulizarIdCorpo = "UPDATE Jogos SET NomeJogo = @Nome,Descricao = @descricao,DataLancamento = @dataLancamento,Valor = @valor,IdEstudio = @estudio Where IdJogo = @ID; ";


                using (SqlCommand cmd = new SqlCommand(queryAtuaulizarIdCorpo, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Nome", jogos.NomeJogo);

                    cmd.Parameters.AddWithValue("@descricao", jogos.Descricao);

                    cmd.Parameters.AddWithValue("@dataLancamento", jogos.DataLancamento);

                    cmd.Parameters.AddWithValue("@valor", jogos.Valor);

                    cmd.Parameters.AddWithValue("idEstudio", jogos.IdEstudio);

                    cmd.Parameters.AddWithValue("ID", jogos.IdJogo);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public JogosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryGetById = "SELECT IdJogo,NomeJogo,Descricao,DataLancamento,Valor,Jogo.IdEstudio,Estudios.IdEstudio,NomeEstudio FROM Jogos INNER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio WHERE IdJogo = @Id";


                using (SqlCommand cmd = new SqlCommand(queryGetById, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogosDomain jogos1 = new JogosDomain
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),
                            NomeJogo = rdr["NomeJogo"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr[3]),
                            Valor = Convert.ToInt32(rdr[4]),
                            IdEstudio = Convert.ToInt32(rdr[5]),
                            EstudiosDomain = new EstudiosDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                NomeEstudio = rdr["NomeEstudio"].ToString()
                            }
                        };
                        return jogos1;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Jogos WHERE IdJogo = @ID";

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
