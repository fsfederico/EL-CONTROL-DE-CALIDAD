using ControlCalidad.Dominio;
using System.Collections.Generic;

namespace ControlCalidad.Aplicacion.Servicios
{
    public interface ILineaTrabajoService : IGenericService<LineaTrabajo>
    {
        IEnumerable<LineaTrabajo> LineasTrabajosVacias();
    }
}
