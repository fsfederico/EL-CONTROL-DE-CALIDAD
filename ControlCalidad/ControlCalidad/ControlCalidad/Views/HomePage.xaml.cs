
using ControlCalidad.Datos;
using ControlCalidad.Presentacion;
using ControlCalidad.ViewModels;
using Xamarin.Forms;

namespace ControlCalidad.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            Settings.Default.Usuario = MockDataStore.Usuarios[1];
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }

}
