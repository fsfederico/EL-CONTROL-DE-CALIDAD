using ControlCalidad.Datos;
using ControlCalidad.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlCalidad.Aplicacion.Servicios
{
    public class OrdenProduccionService : IOrdenProduccionService
    {
        public void AddOrUpdate(OrdenProduccion item)
        {
            item.Estado = Dominio.Enums.Estado.Activo;
            MockDataStore.OrdenesProduccion.AddOrUpdate(item);
        }

        public IEnumerable<OrdenProduccion> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrdenProduccion> GetAllActives()
        {
            throw new NotImplementedException();
        }

        public List<Defecto> GetAllDefectos()
        {
            return MockDataStore.Defectos;
        }

        public OrdenProduccion GetById(int id)
        {
            return MockDataStore.OrdenesProduccion.FirstOrDefault(op => op.Id == id);
        }

        public IEnumerable<OrdenProduccion> GetFiltered(Func<OrdenProduccion, bool> filter)
        {
            return MockDataStore.OrdenesProduccion.Where(filter);
        }

        public void Remove(OrdenProduccion item)
        {
            throw new NotImplementedException();
        }
    }
}
