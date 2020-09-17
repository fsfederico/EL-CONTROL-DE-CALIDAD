using ControlCalidad.Dominio.Entidades;

namespace ControlCalidad.Aplicacion.Servicios
{
    public interface IColoresService
    {
        void CrearColor(string descripcion);
        void EditarColor(Color color);
        void EliminarColor(Color color);
    }
}
