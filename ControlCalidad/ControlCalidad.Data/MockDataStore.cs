using ControlCalidad.Dominio;
using ControlCalidad.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlCalidad.Datos
{
    public static class MockDataStore
    {
        #region Usuarios
        public static List<Usuario> Usuarios = new List<Usuario>() {
            new Usuario{
                Id = 1,
                Apellido= "admin",
                Nombre = "admin",
                CodigoUsuario = "admin",
                Email = "admin",
                Documento = "1",
                Rol = Dominio.Rol.Administrador
            },
            new Usuario{
                Id = 2,
                Apellido= "LINEA",
                Nombre = "LINEA",
                CodigoUsuario = "LINEA",
                Email = "LINEA",
                Documento = "2",
                Rol = Dominio.Rol.SupervisorLinea
            }
        };
        #endregion

        #region Colores
        public static List<Color> Colores = new List<Color>{
            new Color { Id = 1, Descripcion="Rojo", Estado= Dominio.Enums.Estado.Activo },
            new Color { Id = 2, Descripcion="Negro", Estado= Dominio.Enums.Estado.Activo },
            new Color { Id = 3, Descripcion="Blanco", Estado= Dominio.Enums.Estado.Activo }
        };

        // Duda: aca o en el service
        public static IEnumerable<Color> ColoresActivos => Colores.Where(c => c.Estado == Dominio.Enums.Estado.Activo);

        public static int ColorNextId => Colores.Count < 0 ? 1 : Colores.Max(c => c.Id) + 1;
        #endregion

        #region Modelos
        public static List<Modelo> Modelos = new List<Modelo>{
            new Modelo { Id = 1, Denomimacion="Béisbol", SKU="101010", Objetivo= 10, Estado = Dominio.Enums.Estado.Activo },
            new Modelo { Id = 2, Denomimacion="Tenis", SKU="101020", Objetivo= 25, Estado = Dominio.Enums.Estado.Activo },
            new Modelo { Id = 3, Denomimacion="Baloncesto", SKU="101030", Objetivo= 20, Estado = Dominio.Enums.Estado.Activo }
        };

        // Duda: aca o en el service
        public static IEnumerable<Modelo> ModelosActivos => Modelos.Where(c => c.Estado == Dominio.Enums.Estado.Activo);

        public static int ModeloNextId => Modelos.Count < 0 ? 1 : Modelos.Max(c => c.Id) + 1;

        #endregion

        #region Lineas de trabajo
        public static List<LineaTrabajo> LineasTrabajo = new List<LineaTrabajo>
        {
            new LineaTrabajo
            {
                Id = 1,
                Estado = Dominio.Enums.Estado.Activo,
                NumeroLinea = 1
            },
            new LineaTrabajo
            {
                Id = 2,
                Estado = Dominio.Enums.Estado.Activo,
                NumeroLinea = 2
            },
            new LineaTrabajo
            {
                Id = 3,
                Estado = Dominio.Enums.Estado.Activo,
                NumeroLinea = 3
            },
            new LineaTrabajo
            {
                Id = 4,
                Estado = Dominio.Enums.Estado.Activo,
                NumeroLinea = 4
            },
            new LineaTrabajo
            {
                Id = 5,
                Estado = Dominio.Enums.Estado.Activo,
                NumeroLinea = 5
            }
        };
        #endregion

        #region Ordenes de produccion
        public static List<OrdenProduccion> OrdenesProduccion = new List<OrdenProduccion>();
        #endregion

        #region Turnos
        public static List<Turno> Turnos = new List<Turno>
        {
            new Turno{
                Inicio = new TimeSpan(6,0,0),
                Fin = new TimeSpan(15,0,0),
                MinutosPermitidos = 15
            },            
            new Turno{
                Inicio = new TimeSpan(15,30,0),
                Fin = new TimeSpan(0,0,0),
                MinutosPermitidos = 15
            },            
            new Turno{
                Inicio = new TimeSpan(0,30,0),
                Fin = new TimeSpan(5,30,0),
                MinutosPermitidos = 15
            }
        };
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