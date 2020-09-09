using System;

namespace ControlCalidad.Dominio.Entidades
{
    public class Turno : EntityBase
    {
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fin { get; set; }
    }
}
