using PeruNETDevelopment.Services.Dominio;
using PeruNETDevelopment.Services.Errores;
using System.Collections.Generic;
using System.ServiceModel;

namespace PeruNETDevelopment.Services
{
    [ServiceContract]
    public interface IUsuariosServices
    {
        [FaultContract(typeof(UsuarioException))]
        [OperationContract]
        Usuario CrearUsuario(Usuario usuarioACrear);

        [FaultContract(typeof(UsuarioException))]
        [OperationContract]
        Usuario ObtenerUsuario(int nDocumento);

        [OperationContract]
        Usuario ModificarUsuario(Usuario usuarioAModificar);

        [OperationContract]
        void EliminarUsuario(int nDocumento);

        [OperationContract]
        List<Usuario> ListaUsuarios();
    }
}
