using ControlCalidad.Dominio.Enums;
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

        public void IniciarNuevaIspeccion(List<Defecto> defectosReproceso, List<Defecto> defectosObservados, Usuario usuario)
        {
            var inspeccion = new InspeccionOrdenProduccion
            {
                OrdenProduccion = this,
                Supervisor = usuario,
                Hora = DateTime.Now.TimeOfDay - new TimeSpan(0, DateTime.Now.TimeOfDay.Minutes, DateTime.Now.TimeOfDay.Seconds)
            };

            List<CantidadDefecto> cantidadDefectos = new List<CantidadDefecto>();
            cantidadDefectos.AddRange(defectosReproceso.Select(d => new CantidadDefecto
            {
                Defecto = d,
                InspeccionOrdenProduccion = inspeccion,
                CantidadIzquierdo = 0,
                CantidadDerecho = 0
            }));
            cantidadDefectos.AddRange(defectosObservados.Select(d => new CantidadDefecto
            {
                Defecto = d,
                InspeccionOrdenProduccion = inspeccion,
                CantidadIzquierdo = 0,
                CantidadDerecho = 0
            }));
            inspeccion.CantidadesDefecto = cantidadDefectos;
            this.InspeccionesOrdenProduccion.Add(inspeccion);
        }

        public void Finalizar()
        {
            EstadoOrdenProduccion = EstadoOrdenProduccion.Finalizado;
        }

        public void Continuar()
        {
            EstadoOrdenProduccion = EstadoOrdenProduccion.EnProgreso;
        }

        public void Pausar()
        {
            EstadoOrdenProduccion = EstadoOrdenProduccion.Pausado;
        }
    }
}
