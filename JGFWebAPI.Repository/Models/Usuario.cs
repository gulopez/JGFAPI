using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JGFWebAPI.Repository.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string CedulaIdentidad { get; set; }
        public string Clave { get; set; }
        public bool Estado { get; set; }
        public bool SolicitarClave { get; set; }


        public Guid IdPerfil { get; set; }
        [ForeignKey("IdPerfil")]
        public virtual Perfil Perfil { get; set; }
    }
}
