using System.Collections.Generic;

namespace ControlCalidad.Dominio.Entidades
{
    public class Usuario : EntityBase
    {
        public string CodigoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Rol Rol { get; set; }

        public virtual List<OrdenProduccion> OrdenesProduccion { get; set; }
        public virtual List<LineaTrabajo> LineasTrabajo { get; set; }
    }
}
