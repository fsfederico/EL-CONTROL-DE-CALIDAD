using System;

namespace ControlCalidad.Aplicacion.Servicios.Turno.Interface
{
    public interface ITurnoService
    {
        bool PuedeOperar(TimeSpan hora);
    }
}
