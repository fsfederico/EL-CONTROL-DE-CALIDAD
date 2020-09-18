using ControlCalidad.Dominio.Entidades;

namespace ControlCalidad.Aplicacion.Servicios
{
    public interface IModeloService
    {
        void CrearModelo(string denominacion, string SKU, int objetivo);
        void EditarModelo(Modelo modelo);
        void EliminarModelo(Modelo modelo);
    }
}
