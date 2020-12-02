using System;
using System.Collections.Generic;

namespace ControlCalidad.Dominio
{
    public class InspeccionOrdenProduccion : EntityBase
    {
        public int CantidadPrimera { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }

        public virtual OrdenProduccion OrdenProduccion { get; set; }
        public virtual Usuario Supervisor { get; set; }
        public virtual List<CantidadDefecto> CantidadesDefecto { get; set; }
    }
}
