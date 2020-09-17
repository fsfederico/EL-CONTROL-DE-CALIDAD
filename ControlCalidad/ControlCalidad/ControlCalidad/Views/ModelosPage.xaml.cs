using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.Presentacion.ViewModels;
using System;
using Xamarin.Forms;

namespace ControlCalidad.Views
{
    public partial class ModelosPage : ContentPage
    {
        public ModelosPage()
        {
            var coloresService = DependencyService.Resolve<IModelosService>();
            InitializeComponent();
            BindingContext = new ModelosViewModel(coloresService);
        }

        private void EnabledEditCommand(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Grid parent = (Grid)button.Parent;

            foreach (var item in parent.Children)
            {
                if (item.AutomationId?.StartsWith("btn") ?? false)
                    item.IsVisible = !item.IsVisible;
                if (item.AutomationId?.StartsWith("entry") ?? false)
                    item.IsEnabled = !item.IsEnabled;
            }
        }
    }
}