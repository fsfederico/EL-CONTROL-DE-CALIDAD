using ControlCalidad.Dominio.Enums;
using ControlCalidad.Transversal.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlCalidad.Dominio
{
    public class OrdenProduccion : EntityBase
    {
        public OrdenProduccion()
        {
            InspeccionesOrdenProduccion = new List<InspeccionOrdenProduccion>();
        }

        public string Numero { get; set; }
        public EstadoOrdenProduccion EstadoOrdenProduccion { get; set; }

        public virtual LineaTrabajo LineaTrabajo { get; set; }
        public virtual HermanadoOrdenProduccion HermanadoOrdenProduccion { get; set; }
        public virtual List<InspeccionOrdenProduccion> InspeccionesOrdenProduccion { get; set; }
        public virtual Color Color { get; set; }
        public virtual Modelo Modelo { get; set; }

        public bool EnEjecucion => EstadoOrdenProduccion == EstadoOrdenProduccion.EnProgreso || EstadoOrdenProduccion == EstadoOrdenProduccion.Pausado;
        public bool DisponibleInspeccion => EstadoOrdenProduccion == EstadoOrdenProduccion.EnProgreso && !InspeccionesOrdenProduccion.Any();

        public void IniciarNuevaIspeccion(List<Defecto> defectosReproceso, List<Defecto> defectosObservados, Usuario usuario, TimeSpan? hora = null)
        {
            var inspeccion = new InspeccionOrdenProduccion
            {
                OrdenProduccion = this,
                Supervisor = usuario,
                Fecha = DateTime.Now.Date,
                Hora = hora?.GetTime() ?? DateTime.Now.TimeOfDay.GetTime()
            };

            inspeccion.CantidadesDefecto.AddRange(defectosReproceso.Select(d => new CantidadDefecto
            {
                Defecto = d,
                InspeccionOrdenProduccion = inspeccion,
                CantidadIzquierdo = 0,
                CantidadDerecho = 0
            }));

            inspeccion.CantidadesDefecto.AddRange(defectosObservados.Select(d => new CantidadDefecto
            {
                Defecto = d,
                InspeccionOrdenProduccion = inspeccion,
                CantidadIzquierdo = 0,
                CantidadDerecho = 0
            }));

            this.InspeccionesOrdenProduccion.Add(inspeccion);
        }

        public bool ExisteInspeccion(TimeSpan hora)
        {
            return this.InspeccionesOrdenProduccion.Any(iop => iop.Fecha == DateTime.Now.Date && iop.Hora == hora.GetTime());
        }

        public void Finalizar()
        {
            EstadoOrdenProduccion = EstadoOrdenProduccion.Finalizado;
        }

        public void Continuar()
        {
            EstadoOrdenProduccion = EstadoOrdenProduccion.Finalizado == EstadoOrdenProduccion ? EstadoOrdenProduccion : EstadoOrdenProduccion.EnProgreso;
        }

        public void Pausar()
        {
            EstadoOrdenProduccion = EstadoOrdenProduccion.Finalizado == EstadoOrdenProduccion ? EstadoOrdenProduccion : EstadoOrdenProduccion.Pausado;
        }
    }
}
