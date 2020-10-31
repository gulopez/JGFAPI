using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JGFWebAPI.Repository.Models
{
    public class SolicitudCupo
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
        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        public Guid? IdAlumno { get; set; }
        [ForeignKey("IdAlumno")]
        public virtual Alumno Alumno { get; set; }

        public Guid IdPeriodoEscolar { get; set; }
        [ForeignKey("IdPeriodoEscolar")]
        public virtual PeriodoEscolar PeriodoEscolar { get; set; }

        public Guid IdGradoEscolar { get; set; }
        [ForeignKey("IdGradoEscolar")]
        public virtual GradoEscolar GradoEscolar { get; set; }

        public Guid IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public virtual Estado Estado { get; set; }
    }
}
