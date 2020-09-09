using System;

namespace ControlCalidad.Dominio.Entidades
{
    public class HermanadoOrdenProduccion
    {
        public int Id { get; set; }
        public int CantidadPrimera { get; set; }
        public int CantidadSegunda { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Usuario Supervisor { get; set; }
        public virtual OrdenProduccion OrdenProduccion { get; set; }
    }
}
