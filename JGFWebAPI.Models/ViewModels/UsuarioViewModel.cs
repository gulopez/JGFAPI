using System;

namespace JGFWebAPI.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string CedulaIdentidad { get; set; }
        public string Clave { get; set; }
        public Guid IdPerfil { get; set; }
        public PerfilViewModel Perfil { get; set; }
        public bool Estado { get; set; }
        public bool SolicitarClave { get; set; }
    }
}
