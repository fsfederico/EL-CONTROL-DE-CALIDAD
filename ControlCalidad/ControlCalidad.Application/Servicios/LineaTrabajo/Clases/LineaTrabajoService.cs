using ControlCalidad.Datos;
using ControlCalidad.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlCalidad.Aplicacion.Servicios
{
    public class LineaTrabajoService : ILineaTrabajoService
    {
        public void AddOrUpdate(LineaTrabajo item)
        {
                MockDataStore.LineasTrabajo.AddOrUpdate(item);
        }

        public IEnumerable<LineaTrabajo> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineaTrabajo> GetAllActives()
        {
            throw new NotImplementedException();
        }

        public LineaTrabajo GetById(int id)
        {
            return MockDataStore.LineasTrabajo.FirstOrDefault(lt => lt.Id == id);
        }

        public IEnumerable<LineaTrabajo> GetFiltered(Func<LineaTrabajo, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineaTrabajo> LineasTrabajosVacias()
        {
            return MockDataStore
                .LineasTrabajo
                .Where(lt => lt.EstaLibre)
                .Select(lt => new LineaTrabajo
                {
                    Id = lt.Id,
                    Estado = lt.Estado,
                    NumeroLinea = lt.NumeroLinea,
                    OrdenesProduccion = lt.OrdenesProduccion,
                    Supervisores = lt.Supervisores
                });
        }

        public void Remove(LineaTrabajo item)
        {
            throw new NotImplementedException();
        }
    }
}
