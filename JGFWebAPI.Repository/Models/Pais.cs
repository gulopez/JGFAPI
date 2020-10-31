using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Repository.Models
{
    public class Pais
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
    }
}
