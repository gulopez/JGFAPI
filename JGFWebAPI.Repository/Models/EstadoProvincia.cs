using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JGFWebAPI.Repository.Models
{
    public class EstadoProvincia
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Abbreviation { get; set; }

        public Guid IdPais { get; set; }
        [ForeignKey("IdPais")]
        public virtual Pais Pais { get; set; }
    }
}
