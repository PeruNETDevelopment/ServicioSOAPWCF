using PeruNETDevelopment.Services.Dominio;
using PeruNETDevelopment.Services.Errores;
using PeruNETDevelopment.Services.Persistencia;
using System.Collections.Generic;
using System.ServiceModel;

namespace PeruNETDevelopment.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        private UsuarioDAO usuarioDAO = new UsuarioDAO();

        public Usuario CrearUsuario(Usuario usuarioACrear)
        {
            if (usuarioDAO.Obtener(usuarioACrear.nDocumento) != null)
            {
                throw new FaultException<UsuarioException>(
                    new UsuarioException()
                    {
                        Codigo = "101",
                        Descripcion = "El usuario ya existe"
                    },
                    new FaultReason("Error al intentar crear usuario")
                );
            }

            return usuarioDAO.Crear(usuarioACrear);
        }

        public Usuario ObtenerUsuario(int nDocumento)
        {
            if (usuarioDAO.Obtener(nDocumento) == null)
            {
                throw new FaultException<UsuarioException>(
                     new UsuarioException()
                     {
                         Codigo = "102",
                         Descripcion = "El usuario no existe"
                     },
                     new FaultReason("Error al intentar obtener usuario")
                );
            }
            return usuarioDAO.Obtener(nDocumento);
        }

        public Usuario ModificarUsuario(Usuario usuarioAModificar)
        {
            if (usuarioAModificar.sEstado == "I")
            {
                throw new FaultException<UsuarioException>(
                    new UsuarioException()
                    {
                        Codigo = "103",
                        Descripcion = "No se puede modificar usuario con estado Inactivo"
                    }, new FaultReason("Error al intentar modificar usuario")
               );
            }
            return usuarioDAO.Modificar(usuarioAModificar);
        }

        public void EliminarUsuario(int dni) { usuarioDAO.Eliminar(dni); }

        public List<Usuario> ListaUsuarios() { return usuarioDAO.Listar(); }
    }
}