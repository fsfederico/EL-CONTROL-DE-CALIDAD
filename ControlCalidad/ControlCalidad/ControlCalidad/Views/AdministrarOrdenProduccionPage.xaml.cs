
using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.Presentacion.ViewModels;
using Xamarin.Forms;

namespace ControlCalidad.Views
{
    public partial class AdministrarOrdenProduccionPage : ContentPage
    {
        public AdministrarOrdenProduccionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var ordenesProduccionService = DependencyService.Resolve<IOrdenProduccionService>();
            BindingContext = new AdministrarOrdenProduccionViewModel(ordenesProduccionService);
            base.OnAppearing();
        }
    }
}