using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Models.ViewModels
{
    public class EstadoProvinciaViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Abbreviation { get; set; }
        public Guid IdPais { get; set; }
        public PaisViewModel Pais { get; set; }
    }
}
