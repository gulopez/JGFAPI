using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Repository.Models
{
    public class DatosMedicos
    {
        public Guid Id { get; set; }
        public bool IsAlergias { get; set; }
        public string Alergias { get; set; }
        public bool IsServiciosMedicos { get; set; }
        public string Servicios { get; set; }
        public bool IsAfeccion { get; set; }
        public string Afeccion { get; set; }
        public bool IsTratamiento { get; set; }
        public string Tratamiento { get; set; }
    }
}
