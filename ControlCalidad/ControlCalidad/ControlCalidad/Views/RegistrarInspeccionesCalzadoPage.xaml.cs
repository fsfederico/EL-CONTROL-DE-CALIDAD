using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.Presentacion;
using ControlCalidad.Presentacion.ViewModels;
using Xamarin.Forms;

namespace ControlCalidad.Views
{
    public partial class RegistrarInspeccionesCalzadoPage : ContentPage
    {
        public RegistrarInspeccionesCalzadoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var ordenProduccion = DependencyService.Resolve<IOrdenProduccionService>();
            BindingContext = new RegistrarInspeccionesCalzadoViewModel(Settings.Default.OrdenProduccion, ordenProduccion);
            base.OnAppearing();
        }
    }
}