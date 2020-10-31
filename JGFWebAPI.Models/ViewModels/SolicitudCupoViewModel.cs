using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Models.ViewModels
{
    public class SolicitudCupoViewModel
    {
        public Guid Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Telefono { get; set; }
        public string TelefonoAdicional { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid? IdAlumno { get; set; }
        public Guid IdPeriodoEscolar { get; set; }
        public PeriodoEscolarViewModel PeriodoEscolar { get; set; }
        public Guid IdGradoEscolar { get; set; }
        public GradoEscolarViewModel GradoEscolar { get; set; }
        public Guid IdEstado { get; set; }
        public EstadoViewModel Estado { get; set; }
    }
}
