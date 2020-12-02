using NUnit.Framework;

namespace ControlCalidad.Dominio.Test
{
    public class OrdenProduccionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Prueba_Continuar_Orden_Produccion_Pausada()
        {
            //Etapa de Preparacion
            var ordenProduccion = new OrdenProduccion
            {
                EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.Pausado
            };
            //Etapa de Ejecucion
            ordenProduccion.Continuar();
            //Etapa de Comprobacion
            Assert.AreEqual(ordenProduccion.EstadoOrdenProduccion, Enums.EstadoOrdenProduccion.EnProgreso);
        }

        [Test]
        public void Prueba_Continuar_Orden_Produccion_Finalizada()
        {
            //Etapa de Preparacion
            var ordenProduccion = new OrdenProduccion
            {
                EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.Finalizado
            };
            //Etapa de Ejecucion
            ordenProduccion.Continuar();
            //Etapa de Comprobacion
            Assert.AreEqual(ordenProduccion.EstadoOrdenProduccion, Enums.EstadoOrdenProduccion.Finalizado);
        }
    }
}
