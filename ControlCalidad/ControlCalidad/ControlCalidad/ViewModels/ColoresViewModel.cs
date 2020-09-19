using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.Datos;
using ControlCalidad.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Color = ControlCalidad.Dominio.Entidades.Color;

namespace ControlCalidad.Presentacion.ViewModels
{
    public class ColoresViewModel : BaseViewModel
    {
        private IColorService _coloresService { get; set; }
        public ColoresViewModel(IColorService coloresService)
        {
            _coloresService = coloresService;
            ActualizarListadoColores();
            NuevoColor();
            CreateCommand = new Command(OnCreateClicked);
            EditCommand = new Command(OnEditClicked);
            DeleteCommand = new Command(OnDeleteCommand);
            CancelCommand = new Command(OnCancelClicked);
        }

        private void ActualizarListadoColores()
        {
            Colores = new ObservableCollection<Color>(MockDataStore.ColoresActivos.Select(x => new Color { Id = x.Id, Descripcion = x.Descripcion, Estado = x.Estado }));
        }

        private void NuevoColor()
        {
            Color = new Color { Id = MockDataStore.ColorNextId, Descripcion = "" };
        }

        #region List
        private ObservableCollection<Color> _colores;

        public ObservableCollection<Color> Colores
        {
            get { return _colores; }
            set
            {
                _colores = value;
                OnPropertyChanged("Colores");
            }
        }
        #endregion

        #region Create/Edit
        public ICommand CreateCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand CancelCommand { get; }

        private Color _color;
        public Color Color
        {
            get { return this._color; }
            set
            {
                this._color = value;
                OnPropertyChanged("Color");
            }
        }

        private void OnCreateClicked(object obj)
        {
            _coloresService.AddOrUpdate(Color);
            ActualizarListadoColores();
            NuevoColor();
        }

        private void OnEditClicked(object obj)
        {
            _coloresService.AddOrUpdate(obj as Color);
            ActualizarListadoColores();
        }

        private void OnCancelClicked(object obj)
        {
            ActualizarListadoColores();
        }
        #endregion

        #region Delete
        public ICommand DeleteCommand { get; }

        private void OnDeleteCommand(object obj)
        {
            var color = obj as Color;
            color.Eliminar();
            _coloresService.Remove(color);
            ActualizarListadoColores();
        }
        #endregion
    }
}
