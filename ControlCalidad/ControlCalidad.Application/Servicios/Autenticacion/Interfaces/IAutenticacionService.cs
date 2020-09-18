using ControlCalidad.Dominio.Entidades;

namespace ControlCalidad.Aplicacion.Servicios
{
    public interface IAutenticacionService : IGenericService<Usuario>
    {
        Usuario Autenticar(string documento);
    }
}
