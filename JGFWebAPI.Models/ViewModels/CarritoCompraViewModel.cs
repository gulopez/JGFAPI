using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Models.ViewModels
{
    public class CarritoCompraViewModel
    {
        public Guid Id { get; set; }
        public decimal MontoPagar { get; set; }
        public Guid IdAlumno { get; set; }
        public AlumnoViewModel Alumno { get; set; }
        public Guid IdPeriodoEscolar { get; set; }
        public PeriodoEscolarViewModel PeriodoEscolar { get; set; }
        public Guid IdConceptoPago { get; set; }
        public ConceptoPagoViewModel ConceptoPago { get; set; }
        public Guid? IdMesEscolar { get; set; }
        public MesEscolarViewModel MesEscolar { get; set; }
    }
}
