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
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var coloresService = DependencyService.Resolve<IModeloService>();
            BindingContext = new ModelosViewModel(coloresService); 
            base.OnAppearing();
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