using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.Dominio.Entidades;
using ControlCalidad.Presentacion;
using ControlCalidad.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlCalidad.ViewModels
{
    public class InspeccionarCalzadoViewModel : BaseViewModel
    {
        private readonly IOrdenProduccionService _ordenProduccionService;
        public ICommand SelectCommand { get; set; }
        public InspeccionarCalzadoViewModel(IOrdenProduccionService ordenProduccionService)
        {
            _ordenProduccionService = ordenProduccionService;
            OrdenesProduccion = _ordenProduccionService.GetFiltered(op => op.DisponibleInspeccion).ToList();
            if (!OrdenesProduccion.Any())
                MostrarMensaje("Mensaje de advertencia", "No hay ordenes de producción disponibles", "Aceptar");
            SelectCommand = new Command(OnSelectCommand);
        }

        public List<OrdenProduccion> OrdenesProduccion { get; set; }

        public async void OnSelectCommand(object obj)
        {
            Settings.Default.OrdenProduccion = (obj as OrdenProduccion).Id;
            await Shell.Current.GoToAsync($"//{nameof(RegistrarInspeccionesCalzadoPage)}");
        }
    }
}
