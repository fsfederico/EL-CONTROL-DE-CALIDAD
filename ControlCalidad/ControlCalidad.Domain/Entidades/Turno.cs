using System;

namespace ControlCalidad.Dominio.Entidades
{
    public class Turno
    {
        public int Id { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fin { get; set; }
    }
}
