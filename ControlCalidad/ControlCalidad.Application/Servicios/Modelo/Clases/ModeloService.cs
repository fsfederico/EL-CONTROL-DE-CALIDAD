using ControlCalidad.Datos;
using ControlCalidad.Dominio.Entidades;

namespace ControlCalidad.Aplicacion.Servicios
{
    public class ModeloService : IModeloService
    {
        public void CrearModelo(string denominacion, string sku, int objetivo)
        {
            var Modelo = new Modelo
            {
                Denomimacion = denominacion,
                SKU = sku,
                Objetivo = objetivo,
                Estado = Dominio.Enums.Estado.Activo
            };

            MockDataStore.Modelos.AddOrUpdate(Modelo);
        }

        public void EditarModelo(Modelo Modelo)
        {
            MockDataStore.Modelos.AddOrUpdate(Modelo);
        }

        public void EliminarModelo(Modelo Modelo)
        {
            Modelo.Estado = Dominio.Enums.Estado.Eliminado;
            MockDataStore.Modelos.AddOrUpdate(Modelo);
        }

    }
}
