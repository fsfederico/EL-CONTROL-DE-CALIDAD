using ControlCalidad.Dominio.Entidades;
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
        public ICommand InspeccionarCalzadoCommand { get; }
        public ICommand HermanarParesCommand { get; }

        public HomeViewModel()
        {
            ModelosCommand = new Command(OnModelosClicked);
            ColoresCommand = new Command(OnColoresClicked);
            IniciarOPCommand = new Command(OnIniciarOPClicked);
            GestionarOPCommand = new Command(OnGestionarOPClicked);
            InspeccionarCalzadoCommand = new Command(OnInspeccionarCalzadoClicked);
            HermanarParesCommand = new Command(OnHermanarParesClicked);
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

        protected async void OnInspeccionarCalzadoClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(InpeccionarCalzadoPage)}");
        }

        protected async void OnHermanarParesClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(AdministrarOrdenProduccionPage)}");
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }
}
