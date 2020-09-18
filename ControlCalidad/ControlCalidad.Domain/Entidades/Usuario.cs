using System.Collections.Generic;
using System.Linq;

namespace ControlCalidad.Dominio.Entidades
{
    public class Usuario : EntityBase
    {
        public Usuario()
        {
            OrdenesProduccion = new List<OrdenProduccion>();
            LineasTrabajo = new List<LineaTrabajo>();
        }

        public string CodigoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public Rol Rol { get; set; }

        public virtual List<OrdenProduccion> OrdenesProduccion { get; set; }
        public virtual List<LineaTrabajo> LineasTrabajo { get; set; }
        public bool EstaAsignado => OrdenesProduccion.Any(op => op.Estado == Enums.Estado.Activo && op.EstadoOrdenProduccion != Enums.EstadoOrdenProduccion.Finalizado);
    }
}
