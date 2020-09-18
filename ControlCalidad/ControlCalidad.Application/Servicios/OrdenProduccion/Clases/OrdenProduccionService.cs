using ControlCalidad.Datos;
using ControlCalidad.Dominio.Entidades;
using System;
using System.Collections.Generic;

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

        public OrdenProduccion GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrdenProduccion> GetFiltered(Func<OrdenProduccion, bool> filter)
        {
            throw new NotImplementedException();
        }

        public void Remove(OrdenProduccion item)
        {
            throw new NotImplementedException();
        }
    }
}
