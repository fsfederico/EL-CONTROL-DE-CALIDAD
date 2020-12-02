using ControlCalidad.Datos;
using ControlCalidad.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlCalidad.Aplicacion.Servicios
{
    public class ModeloService : IModeloService
    {
        public void AddOrUpdate(Modelo item)
        {
            item.Estado = Dominio.Enums.Estado.Activo;
            MockDataStore.Modelos.AddOrUpdate(item);
        }

        public IEnumerable<Modelo> GetAll()
        {
            return MockDataStore.Modelos;
        }

        public IEnumerable<Modelo> GetAllActives()
        {
            return MockDataStore.Modelos.Where(c => c.Estado == Dominio.Enums.Estado.Activo);
        }

        public Modelo GetById(int id)
        {
            return MockDataStore.Modelos.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Modelo> GetFiltered(Func<Modelo, bool> filter)
        {
            return MockDataStore.Modelos.Where(filter);
        }

        public void Remove(Modelo item)
        {
            MockDataStore.Modelos.AddOrUpdate(item);
        }
    }
}
