using JGFWebAPI.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace JGFWebAPI.Repository.Context
{
    public class FortoulContext : DbContext
    {
        public FortoulContext(DbContextOptions<FortoulContext> options) : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Representante> Representante { get; set; }
        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<GradoEscolar> GradoEscolar { get; set; }
        public virtual DbSet<PeriodoEscolar> PeriodoEscolar { get; set; }
        public virtual DbSet<PreInscripcion> PreInscripcion { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<EstadoProvincia> EstadoProvincia { get; set; }
        public virtual DbSet<DatosMedicos> DatosMedicos { get; set; }
        public virtual DbSet<DatosFamiliares> DatosFamiliares { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivil { get; set; }
        public virtual DbSet<FormaPago> FormaPago { get; set; }
        public virtual DbSet<PagoMaster> PagoMaster { get; set; }
        public virtual DbSet<SolicitudCupo> SolicitudCupo { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<CarritoCompra> CarritoCompra { get; set; }
        public virtual DbSet<ConceptoPago> ConceptoPago { get; set; }
        public virtual DbSet<MesEscolar> MesEscolar { get; set; }
        public virtual DbSet<PagoDetallado> PagoDetallado { get; set; }
        public virtual DbSet<Seccion> Seccion { get; set; }
    }
}
