using ControlCalidad.Datos;
using ControlCalidad.Dominio.Entidades;

namespace ControlCalidad.Aplicacion.Servicios
{
    public class ColorService : IColorService
    {
        public void CrearColor(string descripcion)
        {
            var color = new Color
            {
                Descripcion = descripcion,
                Estado = Dominio.Enums.Estado.Activo
            };

            MockDataStore.Colores.AddOrUpdate(color);
        }

        public void EditarColor(Color color)
        {
            MockDataStore.Colores.AddOrUpdate(color);
        }

        public void EliminarColor(Color color)
        {
            color.Estado = Dominio.Enums.Estado.Eliminado;
            MockDataStore.Colores.AddOrUpdate(color);
        }
    }
}
