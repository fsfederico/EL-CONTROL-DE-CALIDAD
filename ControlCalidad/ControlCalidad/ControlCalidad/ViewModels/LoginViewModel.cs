using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.Presentacion;
using ControlCalidad.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlCalidad.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private IAutenticacionService _autenticacionService { get; set; }
        public ICommand LoginCommand { get; }
        private string _documento;
        public string Documento
        {
            set
            {
                _documento = value;
                CanAuthenticate = !string.IsNullOrEmpty(value);
                OnPropertyChanged("Documento");
                ((Command)LoginCommand).ChangeCanExecute();
            }
            get
            {
                return _documento;
            }
        }

        public bool CanAuthenticate { get; private set; }


        public LoginViewModel(IAutenticacionService autenticacionService)
        {
            _autenticacionService = autenticacionService;
            LoginCommand = new Command(OnLoginClicked, (x) => CanAuthenticate);
        }


        private async void OnLoginClicked(object obj)
        {
            var usuario = _autenticacionService.Autenticar(Documento);
            if (usuario != null)
            {
                Settings.Default.Usuario = usuario;
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
        }
    }
}
