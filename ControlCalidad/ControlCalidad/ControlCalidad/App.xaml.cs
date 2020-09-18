using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.Aplicacion.Servicios.Turno.Interface;
using Xamarin.Forms;

namespace ControlCalidad
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IAutenticacionService, AutenticacionService>();
            DependencyService.Register<IColorService, ColorService>();
            DependencyService.Register<IModeloService, ModeloService>();
            DependencyService.Register<ILineaTrabajoService, LineaTrabajoService>();
            DependencyService.Register<IOrdenProduccionService, OrdenProduccionService>();
            DependencyService.Register<ITurnoService, TurnoService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
