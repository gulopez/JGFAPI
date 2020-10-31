using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JGFWebAPI.Repository.Models
{
    public class PagoDetallado
    {
        public Guid Id { get; set; }
        public string Referencia { get; set; }
        public decimal Monto { get; set; }

        public Guid? IdPagoMaster { get; set; }
        [ForeignKey("IdPagoMaster")]
        public virtual PagoMaster PagoMaster { get; set; }

        public Guid IdFormaPago { get; set; }
        [ForeignKey("IdFormaPago")]
        public virtual FormaPago FormaPago { get; set; }

        public Guid IdRepresentante { get; set; }
        [ForeignKey("IdRepresentante")]
        public virtual Representante Representante { get; set; }
    }
}
