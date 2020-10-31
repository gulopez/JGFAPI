using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JGFWebAPI.Repository.Models
{
    public class Alumno
    {
        public Guid Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public string CedulaAlumno { get; set; }
        public string CarnetEstudiante { get; set; }
        public string LugardeNacimiento { get; set; }
        public string EstadoDeNacimiento { get; set; }
        public string PaisDeNacimiento { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Telefono { get; set; }
        public string TelefonoAdicional { get; set; }
        public string Email { get; set; }
        public string Comentarios { get; set; }
        public string Escolaridad { get; set; }
        public string Materias { get; set; }
        public string PlantelProcedencia { get; set; }

        public Guid IdRepresentante { get; set; }
        [ForeignKey("IdRepresentante")]
        public virtual Representante Representante { get; set; }

        public Guid IdPadre { get; set; }
        [ForeignKey("IdPadre")]
        public virtual Representante Padre { get; set; }

        public Guid IdMadre { get; set; }
        [ForeignKey("IdMadre")]
        public virtual Representante Madre { get; set; }

        public Guid IdDireccion { get; set; }
        [ForeignKey("IdDireccion")]
        public virtual Direccion Direccion { get; set; }

        public Guid IdDatosMedicos { get; set; }
        [ForeignKey("IdDatosMedicos")]
        public virtual DatosMedicos DatosMedicos { get; set; }

        public Guid IdDatosFamiliares { get; set; }
        [ForeignKey("IdDatosFamiliares")]
        public virtual DatosFamiliares DatosFamiliares { get; set; }

        public Guid IdPeriodoEscolar { get; set; }
        [ForeignKey("IdPeriodoEscolar")]
        public virtual PeriodoEscolar PeriodoEscolar { get; set; }

        public Guid IdGradoEscolar { get; set; }
        [ForeignKey("IdGradoEscolar")]
        public virtual GradoEscolar GradoEscolar { get; set; }
    }
}
