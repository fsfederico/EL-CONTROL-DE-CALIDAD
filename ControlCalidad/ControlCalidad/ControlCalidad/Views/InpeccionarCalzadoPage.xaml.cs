
using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.ViewModels;
using Xamarin.Forms;

namespace ControlCalidad.Views
{
    public partial class InpeccionarCalzadoPage : ContentPage
    {
        public InpeccionarCalzadoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var ordenProduccionService = DependencyService.Resolve<IOrdenProduccionService>();
            BindingContext = new InspeccionarCalzadoViewModel(ordenProduccionService);
            base.OnAppearing();
        }
    }
}