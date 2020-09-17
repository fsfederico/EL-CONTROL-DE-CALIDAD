using ControlCalidad.Dominio.Entidades;

namespace ControlCalidad.Aplicacion.Servicios
{
    public interface IAutenticacionService
    {
        Usuario Autenticar(string documento);
    }
}
