using NUnit.Framework;
using System.Collections.Generic;

namespace ControlCalidad.Dominio.Test
{
    public class LineaTrabajoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Prueba_Linea_Trabajo_Libre()
        {
            //GIVEN
            var lineaTrabajo = new LineaTrabajo
            {
                OrdenesProduccion = new List<OrdenProduccion>()
                {
                    new OrdenProduccion
                    {
                        EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.Finalizado
                    },
                    new OrdenProduccion
                    {
                        EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.Finalizado
                    }
                }
            };
            //WHEN
            var estado = lineaTrabajo.EstaLibre;
            //THEN
            Assert.IsTrue(estado);
        }

        [Test]
        public void Prueba_Linea_Trabajo_Ocupada()
        {
            //GIVEN
            var lineaTrabajo = new LineaTrabajo
            {
                OrdenesProduccion = new List<OrdenProduccion>()
                {
                    new OrdenProduccion
                    {
                        EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.Finalizado
                    },
                    new OrdenProduccion
                    {
                        EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.EnProgreso
                    }
                }
            };
            //WHEN
            var estado = lineaTrabajo.EstaLibre;
            //THEN
            Assert.IsFalse(estado);
        }
    }
}