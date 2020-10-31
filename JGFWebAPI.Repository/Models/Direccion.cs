using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JGFWebAPI.Repository.Models
{
    public class Direccion
    {
        public Guid Id { get; set; }
        public string Ciudad { get; set; }
        public string Linea1 { get; set; }
        public string Linea2 { get; set; }
        public string Sector { get; set; }
        public string Urbanizacion { get; set; }
        public string CodigoPostal { get; set; }
        public DateTime FechaModificacion { get; set; }

        public Guid IdEstadoProvincia { get; set; }
        [ForeignKey("IdEstadoProvincia")]
        public virtual EstadoProvincia EstadoProvincia { get; set; }
    }
}
