using AutoMapper;
using JGFWebAPI.Models.ViewModels;
using JGFWebAPI.Repository.Models;

namespace JGFWebAPI.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Perfil, PerfilViewModel>().ReverseMap();
            CreateMap<Representante, RepresentanteViewModel>().ReverseMap();
            CreateMap<Direccion, DireccionViewModel>().ReverseMap();
            CreateMap<EstadoProvincia, EstadoProvinciaViewModel>().ReverseMap();
            CreateMap<Pais, PaisViewModel>().ReverseMap();
            CreateMap<Alumno, AlumnoViewModel>().ReverseMap();
            CreateMap<GradoEscolar, GradoEscolarViewModel>().ReverseMap();
            CreateMap<PeriodoEscolar, PeriodoEscolarViewModel>().ReverseMap();
            CreateMap<PreInscripcion, PreInscripcionViewModel>().ReverseMap();
            CreateMap<DatosFamiliares, DatosFamiliaresViewModel>().ReverseMap();
            CreateMap<DatosMedicos, DatosMedicosViewModel>().ReverseMap();
            CreateMap<EstadoCivil, EstadoCivilViewModel>().ReverseMap();
            CreateMap<FormaPago, FormaPagoViewModel>().ReverseMap();
            CreateMap<PagoMaster, PagoMasterViewModel>().ReverseMap();
            CreateMap<SolicitudCupo, SolicitudCupoViewModel>().ReverseMap();
            CreateMap<Estado, EstadoViewModel>().ReverseMap();
            CreateMap<CarritoCompra, CarritoCompraViewModel>().ReverseMap();
            CreateMap<MesEscolar, MesEscolarViewModel>().ReverseMap();
            CreateMap<ConceptoPago, ConceptoPagoViewModel>().ReverseMap();
            CreateMap<PagoDetallado, PagoDetalladoViewModel>().ReverseMap();
            CreateMap<Seccion, SeccionViewModel>().ReverseMap();
        }
    }
}
