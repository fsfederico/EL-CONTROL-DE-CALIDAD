using ControlCalidad.Dominio.Enums;
using System.Collections.Generic;

namespace ControlCalidad.Dominio.Entidades
{
    public class OrdenProduccion
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public EstadoOrdenProduccion EstadoOrdenProduccion { get; set; }

        public virtual LineaTrabajo LineaTrabajo { get; set; }
        public virtual HermanadoOrdenProduccion HermanadoOrdenProduccion { get; set; }
        public virtual List<InspeccionOrdenProduccion> InspeccionesOrdenProduccion { get; set; }
        public virtual Color Color { get; set; }
        public virtual Modelo Modelo { get; set; }
    }
}
