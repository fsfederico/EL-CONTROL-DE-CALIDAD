using ControlCalidad.Datos;
using ControlCalidad.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControlCalidad.Aplicacion.Servicios
{
    public class AutenticacionService : IAutenticacionService
    {
        public void AddOrUpdate(Usuario color)
        {
            throw new NotImplementedException();
        }

        public Usuario Autenticar(string documento)
        {
            return MockDataStore.Usuarios.FirstOrDefault(u => u.Documento == documento);
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAllActives()
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetFiltered(Expression<Func<Usuario, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetFiltered(Func<Usuario, bool> filter)
        {
            throw new NotImplementedException();
        }

        public void Remove(Usuario color)
        {
            throw new NotImplementedException();
        }
    }
}
