using ControlCalidad.Datos;
using ControlCalidad.Dominio.Entidades;
using System.Linq;

namespace ControlCalidad.Aplicacion.Servicios
{
    public class AutenticacionService : IAutenticacionService
    {
        public Usuario Autenticar(string documento)
        {
            return MockDataStore.Usuarios.FirstOrDefault(u => u.Documento == documento);
        }
    }
}
