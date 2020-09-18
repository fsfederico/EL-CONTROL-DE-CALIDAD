using ControlCalidad.Dominio.Entidades;

namespace ControlCalidad.Aplicacion.Servicios
{
    public interface IColorService
    {
        void CrearColor(string descripcion);
        void EditarColor(Color color);
        void EliminarColor(Color color);
    }
}
