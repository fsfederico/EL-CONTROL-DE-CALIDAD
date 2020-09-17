
using ControlCalidad.ViewModels;
using Xamarin.Forms;

namespace ControlCalidad.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}