using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ControlCalidad.Dominio.Test
{
    public class TurnoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Prueba_Puede_Operar()
        {
            //Etapa de Preparacion
            var turnos = new List<Turno>()
            {
                new Turno
                {
                    Inicio= new System.TimeSpan(18,18,18),
                    Fin = new System.TimeSpan(18,18,20),
                    MinutosPermitidos = 120
                }
            };
            //Etapa de Ejecucion
            var puedeOperar = turnos.Any(t => t.PuedeOperar(new System.TimeSpan(18, 18, 20)));
            //Etapa de Comprobacion
            Assert.IsTrue(puedeOperar);
        }

        [Test]
        public void Prueba_No_Puede_Operar()
        {
            //Etapa de Preparacion
            var turnos = new List<Turno>()
            {
                new Turno
                {
                    Inicio= new System.TimeSpan(18,18,18),
                    Fin = new System.TimeSpan(18,18,20),
                    MinutosPermitidos = 120
                }
            };
            //Etapa de Ejecucion
            var puedeOperar = turnos.Any(t => t.PuedeOperar(new System.TimeSpan(21, 18, 20)));
            //Etapa de Comprobacion
            Assert.IsFalse(puedeOperar);
        }
    }
}
