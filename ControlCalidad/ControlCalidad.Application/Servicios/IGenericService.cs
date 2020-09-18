using ControlCalidad.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace ControlCalidad.Aplicacion.Servicios
{
    public interface IGenericService<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllActives();
        IEnumerable<T> GetFiltered(Func<T, bool> filter);
        T GetById(int id);
        void AddOrUpdate(T item);
        void Remove(T item);
    }
}
