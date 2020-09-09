using ControlCalidad.Dominio.Enums;
using System.Collections.Generic;

namespace ControlCalidad.Dominio.Entidades
{
    public class Defecto
    {
        public int Id { get; set; }
        public string DescripcionDefecto { get; set; }
        public int NumeroDefecto { get; set; }
        public TipoDefecto TipoDefecto { get; set; }

        public virtual List<CantidadDefecto> CantidadesDefecto { get; set; }
    }
}
