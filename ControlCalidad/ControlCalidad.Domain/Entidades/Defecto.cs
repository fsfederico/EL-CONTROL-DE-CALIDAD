using ControlCalidad.Dominio.Enums;
using System.Collections.Generic;

namespace ControlCalidad.Dominio
{
    public class Defecto : EntityBase
    {
        public string DescripcionDefecto { get; set; }
        public TipoDefecto TipoDefecto { get; set; }

        public virtual List<CantidadDefecto> CantidadesDefecto { get; set; }
    }
}
