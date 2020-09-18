using System;

namespace ControlCalidad.Dominio.Entidades
{
    public class Turno : EntityBase
    {
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fin { get; set; }
        public int MinutosPermitidos { get; set; }

        public bool PuedeOperar(TimeSpan hora)
        {
            return hora.TotalMinutes >= Inicio.TotalMinutes && hora.TotalMinutes <= HoraFin.TotalMinutes;
        }

        private TimeSpan HoraFin => Inicio > Fin ? Fin + new TimeSpan(24, MinutosPermitidos, 0) : Fin + new TimeSpan(0, MinutosPermitidos, 0);
    }
}
