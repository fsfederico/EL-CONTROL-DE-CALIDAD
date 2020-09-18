using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.Presentacion.ViewModels;
using System;
using Xamarin.Forms;

namespace ControlCalidad.Views
{
    public partial class ColoresPage : ContentPage
    {
        public ColoresPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var coloresService = DependencyService.Resolve<IColorService>();
            BindingContext = new ColoresViewModel(coloresService);
            base.OnAppearing();
        }

        private void EnabledEditCommand(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Grid parent = (Grid)button.Parent;

            foreach (var item in parent.Children)
            {
                if (item.AutomationId == "btnGuardar")
                    item.IsVisible = !item.IsVisible;
                if (item.AutomationId == "btnEditar")
                    item.IsVisible = !item.IsVisible;
                if (item.AutomationId == "btnCancelar")
                    item.IsVisible = !item.IsVisible;
                if (item.AutomationId == "btnEliminar")
                    item.IsVisible = !item.IsVisible;
                if (item.AutomationId == "entryDesc")
                    item.IsEnabled = !item.IsEnabled;
            }
        }
    }
}