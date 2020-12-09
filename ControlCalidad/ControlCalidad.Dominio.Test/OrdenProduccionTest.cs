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

        [Test]
        public void Prueba_Pausar_Orden_Produccion_Finalizada()
        {
            //Etapa de Preparacion
            var ordenProduccion = new OrdenProduccion
            {
                EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.Finalizado
            };
            //Etapa de Ejecucion
            ordenProduccion.Pausar();
            //Etapa de Comprobacion
            Assert.AreEqual(ordenProduccion.EstadoOrdenProduccion, Enums.EstadoOrdenProduccion.Finalizado);
        }

        [Test]
        public void Prueba_Orden_Produccion_Finalizada_Sin_Ejecucion()
        {
            //Etapa de Preparacion
            var ordenProduccion = new OrdenProduccion
            {
                EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.Finalizado
            };
            //Etapa de Ejecucion
            var enEjecucion = ordenProduccion.EnEjecucion;
            //Etapa de Comprobacion
            Assert.IsFalse(enEjecucion);
        }

        [Test]
        public void Prueba_Orden_Produccion_Pausada_En_Ejecucion()
        {
            //Etapa de Preparacion
            var ordenProduccion = new OrdenProduccion
            {
                EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.Pausado
            };
            //Etapa de Ejecucion
            var enEjecucion = ordenProduccion.EnEjecucion;
            //Etapa de Comprobacion
            Assert.IsTrue(enEjecucion);
        }

        [Test]
        public void Prueba_Orden_Produccion_En_Progreso_En_Ejecucion()
        {
            //Etapa de Preparacion
            var ordenProduccion = new OrdenProduccion
            {
                EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.EnProgreso
            };
            //Etapa de Ejecucion
            var enEjecucion = ordenProduccion.EnEjecucion;
            //Etapa de Comprobacion
            Assert.IsTrue(enEjecucion);
        }

        [Test]
        public void Prueba_Orden_Produccion_Finalizada_No_Disponible_Para_Iniciar_Inspeccion()
        {
            //Etapa de Preparacion
            var ordenProduccion = new OrdenProduccion
            {
                EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.Finalizado
            };

            //Etapa de Ejecucion
            var enEjecucion = ordenProduccion.DisponibleInspeccion;

            //Etapa de Comprobacion
            Assert.IsFalse(enEjecucion);
        }

        [Test]
        public void Prueba_Orden_Produccion_Pausada_No_Disponible_Para_Iniciar_Inspeccion()
        {
            //Etapa de Preparacion
            var ordenProduccion = new OrdenProduccion
            {
                EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.Pausado
            };

            //Etapa de Ejecucion
            var enEjecucion = ordenProduccion.DisponibleInspeccion;

            //Etapa de Comprobacion
            Assert.IsFalse(enEjecucion);
        }

        [Test]
        public void Prueba_Orden_Produccion_En_Progreso_No_Disponible_Para_Iniciar_nspeccion()
        {
            //Etapa de Preparacion
            var ordenProduccion = new OrdenProduccion
            {
                EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.EnProgreso
            };
            ordenProduccion.InspeccionesOrdenProduccion.Add(new InspeccionOrdenProduccion());
            //Etapa de Ejecucion
            var enEjecucion = ordenProduccion.DisponibleInspeccion;

            //Etapa de Comprobacion
            Assert.IsFalse(enEjecucion);
        }

        [Test]
        public void Prueba_Orden_Produccion_En_Progreso_Disponible_Para_Iniciar_nspeccion()
        {
            //Etapa de Preparacion
            var ordenProduccion = new OrdenProduccion
            {
                EstadoOrdenProduccion = Enums.EstadoOrdenProduccion.EnProgreso
            };
            //Etapa de Ejecucion
            var enEjecucion = ordenProduccion.DisponibleInspeccion;

            //Etapa de Comprobacion
            Assert.IsTrue(enEjecucion);
        }
    }
}
