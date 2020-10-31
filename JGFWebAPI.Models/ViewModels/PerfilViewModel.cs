using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Models.ViewModels
{
    public class PerfilViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
