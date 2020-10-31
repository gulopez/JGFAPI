using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JGFWebAPI.Repository.Models
{
    public class CarritoCompra
    {
        public Guid Id { get; set; }
        public decimal MontoPagar { get; set; }

        public Guid IdAlumno { get; set; }
        [ForeignKey("IdAlumno")]
        public virtual Alumno Alumno { get; set; }

        public Guid IdPeriodoEscolar { get; set; }
        [ForeignKey("IdPeriodoEscolar")]
        public virtual PeriodoEscolar PeriodoEscolar { get; set; }

        public Guid IdConceptoPago { get; set; }
        [ForeignKey("IdConceptoPago")]
        public virtual ConceptoPago ConceptoPago { get; set; }

        public Guid? IdMesEscolar { get; set; }
        [ForeignKey("IdMesEscolar")]
        public virtual MesEscolar MesEscolar { get; set; }
    }
}
