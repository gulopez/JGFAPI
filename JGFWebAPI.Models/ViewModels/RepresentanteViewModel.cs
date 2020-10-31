using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Models.ViewModels
{
    public class RepresentanteViewModel
    {
        public Guid Id { get; set; }
        public string Parentesco { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string CedulaRepresentante { get; set; }
        public string Telefono { get; set; }
        public string TelefonoAdicional { get; set; }
        public string Ocupacion { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public string Profesion { get; set; }
        public string EmpresaTrabaja { get; set; }
        public Guid IdDireccion { get; set; }
        public DireccionViewModel Direccion { get; set; }
    }
}
