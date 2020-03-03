using Senai.InLock.WebApi.Domain;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : Iusuario
    {
        private string StringConexao = "Data Source=DEV2\\SQLEXPRESS; initial catalog=T_InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        public List<UsuariosDomain> Listar()
        {
            List<UsuariosDomain> usuarios = new List<UsuariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdUsuario,Nome,Email,Usuario.IdTipoUsuario,TipoUsuario.IdTipoUsuario,Titulo FROM Usuarios INNER JOIN TipoUsuario ON Usuario.IdTipoUsuario = TipoUsuario.Usuario.IdTipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuariosDomain usuarios1 = new UsuariosDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Email = rdr["Email"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr[3]),
                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                Titulo = rdr["Titulo"].ToString()
                            }
                        };
                        usuarios.Add(usuarios1);
                    }
                }
            }
            return usuarios;
        }
        public void AdicionarNovoUsuario(UsuariosDomain usuarios)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Usuarios(Nome,Email,Senha,IdTipoUsuario) VALUES(@Nome,@email,@senha,@tipo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", usuarios.Nome);

                    cmd.Parameters.AddWithValue("@email", usuarios.Email);

                    cmd.Parameters.AddWithValue("@senha", usuarios.Senha);

                    cmd.Parameters.AddWithValue("@tipo", usuarios.TipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void AtualizarIdCorpo(UsuariosDomain usuarios)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryAtuaulizarIdCorpo = "UPDATE Usuarios SET Nome = @Nome,Email = @email,Senha = @senha,IdTipoUsuario = @tipo Where IdUsuario = @ID; ";


                using (SqlCommand cmd = new SqlCommand(queryAtuaulizarIdCorpo, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", usuarios.IdUsuario);

                    cmd.Parameters.AddWithValue("@Nome", usuarios.Nome);

                    cmd.Parameters.AddWithValue("@email", usuarios.Email);

                    cmd.Parameters.AddWithValue("@senha", usuarios.Senha);

                    cmd.Parameters.AddWithValue("@tipo", usuarios.TipoUsuario);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public UsuariosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryGetById = "SELECT IdUsuario,Nome,Email,Usuario.IdTipoUsuario,TipoUsuario.IdTipoUsuario,Titulo FROM Usuarios INNER JOIN TipoUsuario ON Usuario.IdTipoUsuario = TipoUsuario.Usuario.IdTipoUsuario WHERE IdUsuario = @Id"; 


                using (SqlCommand cmd = new SqlCommand(queryGetById, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuariosDomain usuarios1 = new UsuariosDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Email = rdr["Email"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr[3]),
                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                Titulo = rdr["Titulo"].ToString()
                            }
                        };
                        return usuarios1;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Usuarios WHERE IdUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuariosDomain BuscarEmalSenha(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelect = "SELECT IdUsuario,Nome,Email,Senha,Usuarios.IdTipoUsuario,TipoUsuario.IdTipoUsuario,Titulo FROM Usuarios INNER JOIN TipoUsuario ON Usuarios.IdTipoUsuario = TipoUsuario.IdTipoUsuario WHERE Email = @email AND Senha = @senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", Email);

                    cmd.Parameters.AddWithValue("@senha", Senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuariosDomain usuario = new UsuariosDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                Titulo = rdr["Titulo"].ToString()
                            }
                        };

                        return usuario;
                    }
                }
                return null;
            }
        }
    }
}
