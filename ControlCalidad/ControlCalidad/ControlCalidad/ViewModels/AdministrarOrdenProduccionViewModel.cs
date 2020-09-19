using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.Dominio.Entidades;
using ControlCalidad.ViewModels;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlCalidad.Presentacion.ViewModels
{
    public class AdministrarOrdenProduccionViewModel : BaseViewModel
    {
        public bool ContinuarEnabled { get; set; }
        public bool PausarEnabled { get; set; }
        public OrdenProduccion OrdenProduccion { get; set; }
        public ICommand ContinuarCommand { get; set; }
        public ICommand PausarCommand { get; set; }
        public ICommand FinalizarCommand { get; set; }

        private readonly IOrdenProduccionService _ordenProduccionService;

        public AdministrarOrdenProduccionViewModel(IOrdenProduccionService ordenProduccionService)
        {
            _ordenProduccionService = ordenProduccionService;
            OrdenProduccion = Settings.Default.Usuario.LineaOrdenProduccionActual;
            if (OrdenProduccion == null)
                MostrarMensaje("Mensaje de advertencia", "No tiene ninguna orden de producción en curso", "Aceptar");
            ContinuarEnabled = OrdenProduccion.EstadoOrdenProduccion == Dominio.Enums.EstadoOrdenProduccion.Pausado;
            PausarEnabled = OrdenProduccion.EstadoOrdenProduccion == Dominio.Enums.EstadoOrdenProduccion.EnProgreso;
            ContinuarCommand = new Command(OnContinuarCommand);
            PausarCommand = new Command(OnPausarCommand);
            FinalizarCommand = new Command(OnFinalizarCommand);
        }

        public void OnContinuarCommand(object obj)
        {
            OrdenProduccion.Continuar();
            _ordenProduccionService.AddOrUpdate(OrdenProduccion);
            GoHome();
        }

        public void OnPausarCommand(object obj)
        {
            OrdenProduccion.Pausar();
            _ordenProduccionService.AddOrUpdate(OrdenProduccion);
            GoHome();
        }

        public void OnFinalizarCommand(object obj)
        {
            OrdenProduccion.Finalizar();
            _ordenProduccionService.AddOrUpdate(OrdenProduccion);
            GoHome();
        }
    }
}
