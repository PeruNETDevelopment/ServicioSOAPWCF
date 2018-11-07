using System.Runtime.Serialization;

namespace PeruNETDevelopment.Services.Errores
{
    [DataContract]
    public class UsuarioException
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}