using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Models.ViewModels
{
    public class PreInscripcionViewModel
    {
        public Guid Id { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaPreInscripcion { get; set; }
        public DateTime Actualizado { get; set; }
        public Guid IdAlumno { get; set; }
        public AlumnoViewModel Alumno { get; set; }
        public Guid IdPeriodoEscolar { get; set; }
        public PeriodoEscolarViewModel PeriodoEscolar { get; set; }
        public Guid IdGradoEscolar { get; set; }
        public GradoEscolarViewModel GradoEscolar { get; set; }
        public Guid IdUsuario { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public Guid IdEstado { get; set; }
        public EstadoViewModel Estado { get; set; }
        public Guid IdRepresentante { get; set; }
        public RepresentanteViewModel Representante { get; set; }
    }
}
