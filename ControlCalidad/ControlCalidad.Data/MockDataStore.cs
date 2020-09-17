using ControlCalidad.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace ControlCalidad.Datos
{
    public static class MockDataStore
    {
        public static List<Usuario> Usuarios = new List<Usuario>() {
            new Usuario{
                Id = 1,
                Apellido= "admin",
                Nombre = "admin",
                CodigoUsuario = "admin",
                Email = "admin",
                Documento = "1",
                Rol = Dominio.Rol.Administrador
            }
        };

        #region Colores
        public static List<Color> Colores = new List<Color>{
            new Color { Id = 1, Descripcion="Rojo", Estado= Dominio.Enums.Estado.Activo },
            new Color { Id = 2, Descripcion="Negro", Estado= Dominio.Enums.Estado.Activo },
            new Color { Id = 3, Descripcion="Blanco", Estado= Dominio.Enums.Estado.Activo }
        };

        public static IEnumerable<Color> ColoresActivos => Colores.Where(c => c.Estado == Dominio.Enums.Estado.Activo);

        public static int ColorNextId => Colores.Count < 0 ? 1 : Colores.Max(c => c.Id) + 1;
        #endregion

        #region Modelos
        public static List<Modelo> Modelos = new List<Modelo>{
            new Modelo { Id = 1, Denomimacion="Béisbol", SKU="101010", Objetivo= 10, Estado = Dominio.Enums.Estado.Activo },
            new Modelo { Id = 2, Denomimacion="Tenis", SKU="101020", Objetivo= 25, Estado = Dominio.Enums.Estado.Activo },
            new Modelo { Id = 3, Denomimacion="Baloncesto", SKU="101030", Objetivo= 20, Estado = Dominio.Enums.Estado.Activo }
        };

        public static IEnumerable<Modelo> ModelosActivos => Modelos.Where(c => c.Estado == Dominio.Enums.Estado.Activo);

        public static int ModeloNextId => Modelos.Count < 0 ? 1 : Modelos.Max(c => c.Id) + 1;
        #endregion

        public static void AddOrUpdate<T>(this List<T> list, T item) where T : EntityBase
        {
            var index = list.FindIndex(l => l.Id == item.Id);

            if (index >= 0)
            {
                list[index] = item;
            }
            else
            {
                item.Id = list.Count() > 0 ? list.Max(c => c.Id) + 1 : 1;
                list.Add(item);
            }
        }
    }
}