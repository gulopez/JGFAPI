using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Repository.Models
{
    public class Perfil
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
