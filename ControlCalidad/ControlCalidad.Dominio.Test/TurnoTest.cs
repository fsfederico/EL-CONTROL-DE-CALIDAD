using NUnit.Framework;

namespace ControlCalidad.Dominio.Test
{
    public class TurnoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Prueba_Horario_Puede_Operar_En_Turno()
        {
            //Etapa de Preparacion
            var turno = new Turno
            {
                Inicio = new System.TimeSpan(18, 18, 18),
                Fin = new System.TimeSpan(18, 18, 20),
                MinutosPermitidos = 120
            };
            //Etapa de Ejecucion
            var puedeOperar = turno.PuedeOperar(new System.TimeSpan(18, 18, 20));
            //Etapa de Comprobacion
            Assert.IsTrue(puedeOperar);
        }

        [Test]
        public void Prueba_Horario_No_Puede_Operar_En_Turno()
        {
            //Etapa de Preparacion
            var turno = new Turno
            {
                Inicio = new System.TimeSpan(18, 18, 18),
                Fin = new System.TimeSpan(18, 18, 20),
                MinutosPermitidos = 120
            };
            //Etapa de Ejecucion
            var puedeOperar = turno.PuedeOperar(new System.TimeSpan(21, 18, 20));
            //Etapa de Comprobacion
            Assert.IsFalse(puedeOperar);
        }
    }
}
