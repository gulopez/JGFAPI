using System;
using System.Collections.Generic;
using System.Text;

namespace JGFWebAPI.Models.ViewModels
{
    public class PagoDetalladoViewModel
    {
        public Guid Id { get; set; }
        public string Referencia { get; set; }
        public decimal Monto { get; set; }
        public Guid? IdPagoMaster { get; set; }
        public PagoMasterViewModel PagoMaster { get; set; }
        public Guid IdFormaPago { get; set; }
        public FormaPagoViewModel FormaPago { get; set; }
        public Guid IdRepresentante { get; set; }
        public RepresentanteViewModel Representante { get; set; }
    }
}
