using ControlCalidad.Aplicacion.Servicios.Turno.Interface;
using ControlCalidad.Datos;
using System;
using System.Linq;

namespace ControlCalidad.Aplicacion.Servicios
{
    public class TurnoService : ITurnoService
    {
        public bool PuedeOperar(TimeSpan hora)
        {
            return MockDataStore.Turnos.Any(t => t.PuedeOperar(hora));
        }
    }
}
