using ControlCalidad.Datos;
using ControlCalidad.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlCalidad.Aplicacion.Servicios
{
    public class ColorService : IColorService
    {
        public void AddOrUpdate(Color color)
        {
            color.Estado = Dominio.Enums.Estado.Activo;
            MockDataStore.Colores.AddOrUpdate(color);
        }

        public IEnumerable<Color> GetAll()
        {
            return MockDataStore.Colores;
        }

        public IEnumerable<Color> GetAllActives()
        {
            return MockDataStore.Colores.Where(c => c.Estado == Dominio.Enums.Estado.Activo);
        }

        public Color GetById(int id)
        {
            return MockDataStore.Colores.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Color> GetFiltered(Func<Color, bool> filter)
        {
            return MockDataStore.Colores.Where(filter);
        }

        public void Remove(Color color)
        {
            color.Estado = Dominio.Enums.Estado.Eliminado;
            MockDataStore.Colores.AddOrUpdate(color);
        }
    }
}
