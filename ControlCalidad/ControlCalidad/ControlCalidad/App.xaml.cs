using ControlCalidad.Aplicacion.Servicios;
using Xamarin.Forms;

namespace ControlCalidad
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IAutenticacionService, AutenticacionService>();
            DependencyService.Register<IColoresService, ColoresService>();
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
