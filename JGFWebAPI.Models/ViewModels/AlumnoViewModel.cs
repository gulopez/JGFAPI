using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Models.ViewModels
{
    public class AlumnoViewModel
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
        public RepresentanteViewModel Representante { get; set; }
        public Guid IdPadre { get; set; }
        public RepresentanteViewModel Padre { get; set; }
        public Guid IdMadre { get; set; }
        public RepresentanteViewModel Madre { get; set; }
        public Guid IdDireccion { get; set; }
        public DireccionViewModel Direccion { get; set; }
        public Guid IdDatosMedicos { get; set; }
        public DatosMedicosViewModel DatosMedicos { get; set; }
        public Guid IdDatosFamiliares { get; set; }
        public DatosFamiliaresViewModel DatosFamiliares { get; set; }
        public Guid IdPeriodoEscolar { get; set; }
        public PeriodoEscolarViewModel PeriodoEscolar { get; set; }
        public Guid IdGradoEscolar { get; set; }
        public GradoEscolarViewModel GradoEscolar { get; set; }
    }
}
