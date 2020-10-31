using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Repository.Models
{
    public class DatosFamiliares
    {
        public Guid Id { get; set; }
        public string Religion { get; set; }
        public string Hermanos { get; set; }
        public string Ingresos { get; set; }
        public string Personas { get; set; }
        public string EstadoCivil { get; set; }
    }
}
