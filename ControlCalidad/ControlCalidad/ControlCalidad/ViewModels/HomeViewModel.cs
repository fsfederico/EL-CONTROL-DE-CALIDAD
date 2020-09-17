using ControlCalidad.Presentacion;
using ControlCalidad.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlCalidad.ViewModels
{
    public class HomeViewModel
    {
        public ICommand ModelosCommand { get; }
        public ICommand ColoresCommand { get; }

        public HomeViewModel()
        {
            ModelosCommand = new Command(OnModelosClicked);
            ColoresCommand = new Command(OnColoresClicked);
        }


        private async void OnModelosClicked(object obj)
        {
            if (Settings.Default.Usuario != null)
            {
                await Shell.Current.GoToAsync($"//{nameof(ModelosPage)}");
            }
        }

        private async void OnColoresClicked(object obj)
        {
            if (Settings.Default.Usuario != null)
            {
            }
            await Shell.Current.GoToAsync($"//{nameof(ColoresPage)}");
        }

    }
}
