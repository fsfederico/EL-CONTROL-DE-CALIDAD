using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace ControlCalidad.Presentacion.ViewModels
{
    public class RegistrarInspeccionesCalzadoViewModel
    {
        private readonly IOrdenProduccionService _ordenProduccion;
        public OrdenProduccion OrdenProduccion { get; set; }
        public List<CantidadDefecto> DefectosReproceso { get; set; }
        public List<CantidadDefecto> DefectosObservados { get; set; }
        public string Usuario { get; set; }
        public RegistrarInspeccionesCalzadoViewModel(int id, IOrdenProduccionService ordenProduccion)
        {
            _ordenProduccion = ordenProduccion;
            OrdenProduccion = _ordenProduccion.GetById(id);
            var defectosObservados = _ordenProduccion.GetAllDefectos().Where(d => d.TipoDefecto == Dominio.Enums.TipoDefecto.Observado).ToList();
            var defectosReproceso = _ordenProduccion.GetAllDefectos().Where(d => d.TipoDefecto == Dominio.Enums.TipoDefecto.Reprocesado).ToList();
            Usuario = Settings.Default.Usuario.Apellido;
            OrdenProduccion.IniciarNuevaIspeccion(defectosReproceso, defectosObservados, Settings.Default.Usuario);
            DefectosReproceso = OrdenProduccion.InspeccionesOrdenProduccion.Last().CantidadesDefecto.Where(d => d.Defecto.TipoDefecto == Dominio.Enums.TipoDefecto.Reprocesado).ToList();
            DefectosObservados = OrdenProduccion.InspeccionesOrdenProduccion.Last().CantidadesDefecto.Where(d => d.Defecto.TipoDefecto == Dominio.Enums.TipoDefecto.Observado).ToList();
        }
    }
}
