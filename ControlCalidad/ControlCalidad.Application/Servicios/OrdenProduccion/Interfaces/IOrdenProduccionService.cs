using ControlCalidad.Dominio.Entidades;
using System.Collections.Generic;

namespace ControlCalidad.Aplicacion.Servicios
{
    public interface IOrdenProduccionService : IGenericService<OrdenProduccion>
    {
        List<Defecto> GetAllDefectos();
    }
}
