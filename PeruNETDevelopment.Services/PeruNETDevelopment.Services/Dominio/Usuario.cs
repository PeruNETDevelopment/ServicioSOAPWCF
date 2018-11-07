using System.Runtime.Serialization;

namespace PeruNETDevelopment.Services.Dominio
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int cUsuario { get; set; }
        [DataMember]
        public string sUsuario { get; set; }
        [DataMember]
        public string dContraseña { get; set; }
        [DataMember]
        public int nDocumento { get; set; }
        [DataMember(IsRequired = false)]
        public string sEstado { get; set; }
    }
}