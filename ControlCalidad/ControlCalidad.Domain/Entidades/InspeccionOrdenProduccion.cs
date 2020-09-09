using System;
using System.Collections.Generic;

namespace ControlCalidad.Dominio.Entidades
{
    public class InspeccionOrdenProduccion
    {
        public int Id { get; set; }
        public int CantidadPrimera { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }

        public virtual OrdenProduccion OrdenProduccion { get; set; }
        public virtual Usuario Supervisor { get; set; }
        public virtual List<CantidadDefecto> CantidadesDefecto { get; set; }
    }
}
