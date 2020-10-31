using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JGFWebAPI.Repository.Models
{
    public class PreInscripcion
    {
        public Guid Id { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaPreInscripcion { get; set; }
        public DateTime Actualizado { get; set; }

        public Guid IdAlumno { get; set; }
        [ForeignKey("IdAlumno")]
        public virtual Alumno Alumno { get; set; }

        public Guid IdPeriodoEscolar { get; set; }
        [ForeignKey("IdPeriodoEscolar")]
        public virtual PeriodoEscolar PeriodoEscolar { get; set; }

        public Guid IdGradoEscolar { get; set; }
        [ForeignKey("IdGradoEscolar")]
        public virtual GradoEscolar GradoEscolar { get; set; }

        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        public Guid IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public virtual Estado Estado { get; set; }

        public Guid IdRepresentante { get; set; }
        [ForeignKey("IdRepresentante")]
        public virtual Representante Representante { get; set; }
    }
}
