using PeruNETDevelopment.Services.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PeruNETDevelopment.Services.Persistencia
{
    public class UsuarioDAO
    {
        private string CadenaConexion = "Data Source=DESKTOP-F4VV2GP\\SQLEXPRESS;Initial Catalog=DB_DSD_GOV;User ID=sa;Password=123;";

        public Usuario Crear(Usuario usuarioACrear)
        {
            Usuario usuarioCreado = null;
            string sql = "Insert into usuario values(@susuario, @dcontraseña, @ndocumento, @sestado)";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@susuario", usuarioACrear.sUsuario));
                    comando.Parameters.Add(new SqlParameter("@dcontraseña", usuarioACrear.dContraseña));
                    comando.Parameters.Add(new SqlParameter("@ndocumento", usuarioACrear.nDocumento));
                    comando.Parameters.Add(new SqlParameter("@sestado", usuarioACrear.sEstado));
                    comando.ExecuteNonQuery();
                }
            }
            usuarioCreado = Obtener(usuarioACrear.nDocumento);
            return usuarioCreado;
        }

        public Usuario Obtener(int nDocumento)
        {
            Usuario usuarioEncontrado = null;
            string sql = "SELECT * FROM Usuario WHERE nDocumento = @ndocumento";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@ndocumento", nDocumento));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            usuarioEncontrado = new Usuario
                            {
                                cUsuario = (int)resultado["cUsuario"],
                                sUsuario = (string)resultado["sUsuario"],
                                dContraseña = (string)resultado["dContraseña"],
                                nDocumento = (int)resultado["nDocumento"],
                                sEstado = (string)resultado["sEstado"]
                            };
                        }
                    }
                }
            }
            return usuarioEncontrado;
        }

        public Usuario Modificar(Usuario usuarioAModificar)
        {
            Usuario usuarioModificado = null;
            var sql = "update usuario set sUsuario = @susuario, dcontraseña = @dcontraseña where ndocumento = @ndocumento";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@susuario", usuarioAModificar.sUsuario));
                    comando.Parameters.Add(new SqlParameter("@dcontraseña", usuarioAModificar.dContraseña));
                    comando.Parameters.Add(new SqlParameter("@ndocumento", usuarioAModificar.nDocumento));
                    comando.ExecuteNonQuery();
                }
            }
            usuarioModificado = Obtener(usuarioAModificar.nDocumento);
            return usuarioModificado;
        }

        public void Eliminar(int dni)
        {
            var sql = "DELETE FROM usuario WHERE ndocumento = @ndocumento";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@ndocumento", dni));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Usuario> Listar()
        {
            List<Usuario> usuariosEncontrados = new List<Usuario>();
            Usuario usuarioEncontrado = null;
            var sql = "SELECT * FROM usuario";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            usuarioEncontrado = new Usuario()
                            {
                                cUsuario = (int)resultado["cUsuario"],
                                sUsuario = (string)resultado["sUsuario"],
                                dContraseña = (string)resultado["dContraseña"],
                                sEstado = (string)resultado["sEstado"]
                            };

                            usuariosEncontrados.Add(usuarioEncontrado);
                        }
                    }
                }
                return usuariosEncontrados;
            }

        }
    }
}