using ControlCalidad.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace ControlCalidad.Dominio
{
    public class LineaTrabajo : EntityBase
    {
        public LineaTrabajo()
        {
            Supervisores = new List<Usuario>();
            OrdenesProduccion = new List<OrdenProduccion>();
        }

        public int NumeroLinea { get; set; }
        public virtual List<Usuario> Supervisores { get; set; }
        public virtual List<OrdenProduccion> OrdenesProduccion { get; set; }
        public bool EstaLibre => Estado == Enums.Estado.Activo &&
            OrdenesProduccion.All(op => op.EstadoOrdenProduccion == Enums.EstadoOrdenProduccion.Finalizado);
    }
}
