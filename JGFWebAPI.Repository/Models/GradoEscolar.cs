using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Repository.Models
{
    public class GradoEscolar
    {
        public Guid Id { get; set; }
        public string Grado { get; set; }
        public int Orden { get; set; }
    }
}
