using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Models.ViewModels
{
    public class FormaPagoViewModel
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public bool Estado { get; set; }
    }
}
