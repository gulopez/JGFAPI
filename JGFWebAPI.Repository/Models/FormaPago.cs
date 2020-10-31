using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Repository.Models
{
    public class FormaPago
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public bool Estado { get; set; }
    }
}
