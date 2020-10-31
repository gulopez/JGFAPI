using AutoMapper;
using JGFWebAPI.Bussiness.Interfaces;
using JGFWebAPI.Models.ViewModels;
using JGFWebAPI.Repository.Context;
using JGFWebAPI.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JGFWebAPI.Bussiness.Bussiness
{
    public class AlumnoBussiness : IGeneric<AlumnoViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public AlumnoBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(AlumnoViewModel entity)
        {            
            _fortoulContext.Add(_mapper.Map<Alumno>(entity));
            return Save();
        }

        public bool DeleteEntity(AlumnoViewModel entity)
        {
            _fortoulContext.Remove(_mapper.Map<Alumno>(entity));
            return Save();
        }

        public bool ExistsEntity(string keyword)
        {
            return _fortoulContext.Alumno.Any(u => u.PrimerApellido.ToLower().Trim() == keyword.ToLower().Trim() ||
                                              u.SegundoApellido.ToLower().Trim() == keyword.ToLower().Trim() ||
                                              u.PrimerNombre.ToLower().Trim() == keyword.ToLower().Trim() ||
                                              u.SegundoNombre.ToLower().Trim() == keyword.ToLower().Trim());
        }

        public bool ExistsEntityByCardId(string cardId)
        {
            return _fortoulContext.Alumno.Any(u => u.CedulaAlumno == cardId || u.CarnetEstudiante == cardId);
        }

        public bool ExistsEntity(Guid id)
        {
            return _fortoulContext.Alumno.Any(a => a.Id == id);
        }

        public ICollection<AlumnoViewModel> GetEntities()
        {
            var alumnos = _fortoulContext.Alumno
                          .Include(r => r.Representante)
                          .Include(rd => rd.Representante.Direccion)
                          .Include(rd => rd.Representante.Direccion.EstadoProvincia)
                          .Include(rd => rd.Representante.Direccion.EstadoProvincia.Pais)
                          .Include(p => p.Padre)
                          .Include(pd => pd.Padre.Direccion)
                          .Include(pd => pd.Padre.Direccion.EstadoProvincia)
                          .Include(pd => pd.Padre.Direccion.EstadoProvincia.Pais)
                          .Include(m => m.Madre)
                          .Include(md => md.Madre.Direccion)
                          .Include(md => md.Madre.Direccion.EstadoProvincia)
                          .Include(md => md.Madre.Direccion.EstadoProvincia.Pais)
                          .Include(a => a.Direccion)
                          .Include(a => a.Direccion.EstadoProvincia)
                          .Include(a => a.Direccion.EstadoProvincia.Pais)
                          .Include(dm => dm.DatosMedicos)
                          .Include(df => df.DatosFamiliares)
                          .Include(p => p.PeriodoEscolar)
                          .Include(g => g.GradoEscolar)
                          .OrderBy(a => a.PrimerApellido)
                          .AsNoTracking()
                          .ToList();
            var alumnosViewModel = new List<AlumnoViewModel>();
            foreach (var item in alumnos)
            {
                alumnosViewModel.Add(_mapper.Map<AlumnoViewModel>(item));
            }
            return alumnosViewModel;
        }

        public object GetEntitiesByPreInscription()
        {
            List<Guid> preIds = _fortoulContext.PreInscripcion
                                .Where(pi => pi.Estado.Tipo == "Nuevo")
                                .Select(pi => pi.IdAlumno)
                                .ToList();

            var alumnos = _fortoulContext.Alumno
                          .Include(r => r.Representante)
                          .Include(rd => rd.Representante.Direccion)
                          .Include(rd => rd.Representante.Direccion.EstadoProvincia)
                          .Include(rd => rd.Representante.Direccion.EstadoProvincia.Pais)
                          .Include(p => p.Padre)
                          .Include(pd => pd.Padre.Direccion)
                          .Include(pd => pd.Padre.Direccion.EstadoProvincia)
                          .Include(pd => pd.Padre.Direccion.EstadoProvincia.Pais)
                          .Include(m => m.Madre)
                          .Include(md => md.Madre.Direccion)
                          .Include(md => md.Madre.Direccion.EstadoProvincia)
                          .Include(md => md.Madre.Direccion.EstadoProvincia.Pais)
                          .Include(a => a.Direccion)
                          .Include(a => a.Direccion.EstadoProvincia)
                          .Include(a => a.Direccion.EstadoProvincia.Pais)
                          .Include(dm => dm.DatosMedicos)
                          .Include(df => df.DatosFamiliares)
                          .Include(p => p.PeriodoEscolar)
                          .Include(g => g.GradoEscolar)
                          .Where(a => preIds.Contains(a.Id))
                          .OrderBy(a => a.PrimerApellido)
                          .AsNoTracking()
                          .ToList();
            var alumnosViewModel = new List<AlumnoViewModel>();
            foreach (var item in alumnos)
            {
                alumnosViewModel.Add(_mapper.Map<AlumnoViewModel>(item));
            }
            return alumnosViewModel;
        }

        public AlumnoViewModel GetEntity(Guid id)
        {
            var alumno = _fortoulContext.Alumno
                        .Include(a => a.Direccion)
                        .Include(a => a.Direccion.EstadoProvincia)
                        .Include(a => a.Direccion.EstadoProvincia.Pais)
                        .Include(r => r.Representante)
                        .Include(rd => rd.Representante.Direccion)
                        .Include(rd => rd.Representante.Direccion.EstadoProvincia)
                        .Include(rd => rd.Representante.Direccion.EstadoProvincia.Pais)
                        .Include(p => p.Padre)
                        .Include(pd => pd.Padre.Direccion)
                        .Include(pd => pd.Padre.Direccion.EstadoProvincia)
                        .Include(pd => pd.Padre.Direccion.EstadoProvincia.Pais)
                        .Include(m => m.Madre)
                        .Include(md => md.Madre.Direccion)
                        .Include(md => md.Madre.Direccion.EstadoProvincia)
                        .Include(md => md.Madre.Direccion.EstadoProvincia.Pais)
                        .Include(dm => dm.DatosMedicos)
                        .Include(df => df.DatosFamiliares)
                        .Include(p => p.PeriodoEscolar)
                        .Include(g => g.GradoEscolar)
                        .Where(u => u.Id == id)
                        .AsNoTracking()
                        .FirstOrDefault();
            var alumnoViewModel = _mapper.Map<AlumnoViewModel>(alumno);
            return alumnoViewModel;
        }

        public bool Save()
        {
            return _fortoulContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEntity(AlumnoViewModel entity)
        {
            _fortoulContext.Update(_mapper.Map<Alumno>(entity));
            return Save();
        }

        public ICollection<AlumnoViewModel> GetEntitiesByRepresentative(Guid id, bool cupo)
        {
            var alumnos = _fortoulContext.Alumno.ToList();
            if (cupo)
            {
                List<Guid?> idsCupos = _fortoulContext.SolicitudCupo
                                 .Where(sc => sc.Estado.Tipo == "Solicitado")
                                 .Select(sc => sc.IdAlumno)
                                 .ToList();

                alumnos = _fortoulContext.Alumno
                        .Include(r => r.Representante)
                        .Include(rd => rd.Representante.Direccion)
                        .Include(rd => rd.Representante.Direccion.EstadoProvincia)
                        .Include(rd => rd.Representante.Direccion.EstadoProvincia.Pais)
                        .Include(p => p.Padre)
                        .Include(pd => pd.Padre.Direccion)
                        .Include(pd => pd.Padre.Direccion.EstadoProvincia)
                        .Include(pd => pd.Padre.Direccion.EstadoProvincia.Pais)
                        .Include(m => m.Madre)
                        .Include(md => md.Madre.Direccion)
                        .Include(md => md.Madre.Direccion.EstadoProvincia)
                        .Include(md => md.Madre.Direccion.EstadoProvincia.Pais)
                        .Include(a => a.Direccion)
                        .Include(a => a.Direccion.EstadoProvincia)
                        .Include(a => a.Direccion.EstadoProvincia.Pais)
                        .Include(dm => dm.DatosMedicos)
                        .Include(df => df.DatosFamiliares)
                        .Include(p => p.PeriodoEscolar)
                        .Include(g => g.GradoEscolar)
                        .Where(a => (a.IdRepresentante == id || a.IdPadre == id || a.IdMadre == id) && !idsCupos.Contains(a.Id))
                        .OrderBy(a => a.PrimerApellido)
                        .AsNoTracking()
                        .ToList();
            }
            else
            {
                alumnos = _fortoulContext.Alumno
                        .Include(r => r.Representante)
                        .Include(rd => rd.Representante.Direccion)
                        .Include(rd => rd.Representante.Direccion.EstadoProvincia)
                        .Include(rd => rd.Representante.Direccion.EstadoProvincia.Pais)
                        .Include(p => p.Padre)
                        .Include(pd => pd.Padre.Direccion)
                        .Include(pd => pd.Padre.Direccion.EstadoProvincia)
                        .Include(pd => pd.Padre.Direccion.EstadoProvincia.Pais)
                        .Include(m => m.Madre)
                        .Include(md => md.Madre.Direccion)
                        .Include(md => md.Madre.Direccion.EstadoProvincia)
                        .Include(md => md.Madre.Direccion.EstadoProvincia.Pais)
                        .Include(a => a.Direccion)
                        .Include(a => a.Direccion.EstadoProvincia)
                        .Include(a => a.Direccion.EstadoProvincia.Pais)
                        .Include(dm => dm.DatosMedicos)
                        .Include(df => df.DatosFamiliares)
                        .Include(p => p.PeriodoEscolar)
                        .Include(g => g.GradoEscolar)
                        .Where(a => (a.IdRepresentante == id || a.IdPadre == id || a.IdMadre == id))
                        .OrderBy(a => a.PrimerApellido)
                        .AsNoTracking()
                        .ToList();
            }
            
            var alumnosViewModel = new List<AlumnoViewModel>();
            foreach (var item in alumnos)
            {
                alumnosViewModel.Add(_mapper.Map<AlumnoViewModel>(item));
            }
            return alumnosViewModel;
        }

        public ICollection<AlumnoViewModel> GetEntitiesByKeyword(string keyword)
        {
            var alumnos = _fortoulContext.Alumno
                          .Include(r => r.Representante)
                          .Include(rd => rd.Representante.Direccion)
                          .Include(rd => rd.Representante.Direccion.EstadoProvincia)
                          .Include(rd => rd.Representante.Direccion.EstadoProvincia.Pais)
                          .Include(p => p.Padre)
                          .Include(pd => pd.Padre.Direccion)
                          .Include(pd => pd.Padre.Direccion.EstadoProvincia)
                          .Include(pd => pd.Padre.Direccion.EstadoProvincia.Pais)
                          .Include(m => m.Madre)
                          .Include(md => md.Madre.Direccion)
                          .Include(md => md.Madre.Direccion.EstadoProvincia)
                          .Include(md => md.Madre.Direccion.EstadoProvincia.Pais)
                          .Include(a => a.Direccion)
                          .Include(a => a.Direccion.EstadoProvincia)
                          .Include(a => a.Direccion.EstadoProvincia.Pais)
                          .Include(dm => dm.DatosMedicos)
                          .Include(df => df.DatosFamiliares)
                          .Include(p => p.PeriodoEscolar)
                          .Include(g => g.GradoEscolar)
                          .Where(a => a.CedulaAlumno.Contains(keyword) || a.CarnetEstudiante.Contains(keyword) || a.PrimerNombre.Contains(keyword)
                                 || a.SegundoNombre.Contains(keyword) || a.PrimerApellido.Contains(keyword) || a.SegundoApellido.Contains(keyword))
                          .ToList();

            var alumnosViewModel = new List<AlumnoViewModel>();
            foreach (var item in alumnos)
            {
                alumnosViewModel.Add(_mapper.Map<AlumnoViewModel>(item));
            }
            return alumnosViewModel;
        }
    }
}
