using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Models.ViewModels
{
    public class PagoMasterViewModel
    {
        public Guid Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public Guid IdAlumno { get; set; }
        public virtual AlumnoViewModel Alumno { get; set; }
        public Guid IdPeriodoEscolar { get; set; }
        public virtual PeriodoEscolarViewModel PeriodoEscolar { get; set; }
        public Guid IdConceptoPago { get; set; }
        public ConceptoPagoViewModel ConceptoPago { get; set; }
        public Guid? IdMesEscolar { get; set; }
        public virtual MesEscolarViewModel MesEscolar { get; set; }
    }
}
