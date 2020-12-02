using ControlCalidad.Dominio;

namespace ControlCalidad.Aplicacion.Servicios
{
    public interface IAutenticacionService : IGenericService<Usuario>
    {
        Usuario Autenticar(string documento);
    }
}
