using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Models.ViewModels
{
    public class PaisViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
    }
}
