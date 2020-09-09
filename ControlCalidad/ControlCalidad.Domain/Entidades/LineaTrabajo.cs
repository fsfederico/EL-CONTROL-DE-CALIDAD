using ControlCalidad.Dominio.Entidades;
using System.Collections.Generic;

namespace ControlCalidad.Dominio
{
    public class LineaTrabajo
    {
        public int Id { get; set; }
        public int NumeroLinea { get; set; }
        public virtual List<Usuario> Supervisores { get; set; }
        public virtual List<OrdenProduccion> OrdenesProduccion { get; set; }
    }
}
