using ControlCalidad.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlCalidad.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand ModelosCommand { get; }
        public ICommand ColoresCommand { get; }
        public ICommand IniciarOPCommand { get; }
        public ICommand GestionarOPCommand { get; }

        public HomeViewModel()
        {
            ModelosCommand = new Command(OnModelosClicked, (x) => EsAdministrador);
            ColoresCommand = new Command(OnColoresClicked, (x) => EsAdministrador);
            IniciarOPCommand = new Command(OnIniciarOPClicked, (x) => EsSupervisorLinea);
            GestionarOPCommand = new Command(OnGestionarOPClicked, (x) => EsSupervisorLinea);
        }


        private async void OnModelosClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(ModelosPage)}");
        }

        protected async void OnColoresClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(ColoresPage)}");
        }

        protected async void OnIniciarOPClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(IniciarOrdenProduccionPage)}");
        }

        protected async void OnGestionarOPClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(AdministrarOrdenProduccionPage)}");
        }
    }
}
