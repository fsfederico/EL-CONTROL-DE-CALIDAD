using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.Aplicacion.Servicios.Turno.Interface;
using ControlCalidad.Presentacion.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlCalidad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IniciarOrdenProduccionPage : ContentPage
    {
        public IniciarOrdenProduccionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var lineaTrabajoService = DependencyService.Resolve<ILineaTrabajoService>();
            var ordenProduccionService = DependencyService.Resolve<IOrdenProduccionService>();
            var colorService = DependencyService.Resolve<IColorService>();
            var modeloService = DependencyService.Resolve<IModeloService>();
            var turnoService = DependencyService.Resolve<ITurnoService>();

            BindingContext = new IniciarOrdenProduccionViewModel(lineaTrabajoService,
                ordenProduccionService,
                colorService,
                modeloService,
                turnoService);
            base.OnAppearing();
        }
    }
}