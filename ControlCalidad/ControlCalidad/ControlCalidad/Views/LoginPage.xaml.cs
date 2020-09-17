using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.ViewModels;
using Xamarin.Forms;

namespace ControlCalidad.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var autenticacionService = DependencyService.Resolve<IAutenticacionService>();
            InitializeComponent();
            this.BindingContext = new LoginViewModel(autenticacionService);
        }
    }
}