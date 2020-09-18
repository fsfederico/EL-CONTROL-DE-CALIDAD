using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.Datos;
using ControlCalidad.Dominio.Entidades;
using ControlCalidad.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlCalidad.Presentacion.ViewModels
{
    public class ModelosViewModel : BaseViewModel
    {
        private IModeloService _modelosService { get; set; }
        public ModelosViewModel(IModeloService modelosService)
        {
            _modelosService = modelosService;
            ActualizarListadoModelos();
            NuevoModelo();
            CreateCommand = new Command(OnCreateClicked);
            EditCommand = new Command(OnEditClicked);
            DeleteCommand = new Command(OnDeleteCommand);
            CancelCommand = new Command(OnCancelClicked);
        }

        private void ActualizarListadoModelos()
        {
            Modelos = new ObservableCollection<Modelo>(MockDataStore.ModelosActivos.Select(x => new Modelo { Id = x.Id, Denomimacion = x.Denomimacion, SKU = x.SKU, Objetivo = x.Objetivo, Estado = x.Estado }));
        }

        private void NuevoModelo()
        {
            Modelo = new Modelo { Id = MockDataStore.ModeloNextId, Denomimacion = "", SKU = "" };
        }

        #region List
        private ObservableCollection<Modelo> _modelos;

        public ObservableCollection<Modelo> Modelos
        {
            get { return _modelos; }
            set
            {
                _modelos = value;
                OnPropertyChanged("Modelos");
            }
        }
        #endregion

        #region Create/Edit
        public ICommand CreateCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand CancelCommand { get; }

        private Modelo _modelo;
        public Modelo Modelo
        {
            get { return this._modelo; }
            set
            {
                this._modelo = value;
                OnPropertyChanged("Modelo");
            }
        }

        private void OnCreateClicked(object obj)
        {
            _modelosService.AddOrUpdate(Modelo);
            ActualizarListadoModelos();
            NuevoModelo();
        }

        private void OnEditClicked(object obj)
        {
            _modelosService.AddOrUpdate(obj as Modelo);
            ActualizarListadoModelos();
        }

        private void OnCancelClicked(object obj)
        {
            ActualizarListadoModelos();
        }
        #endregion

        #region Delete
        public ICommand DeleteCommand { get; }

        private void OnDeleteCommand(object obj)
        {
            _modelosService.Remove(obj as Modelo);
            ActualizarListadoModelos();
        }
        #endregion

    }
}
