using ControlCalidad.Aplicacion.Servicios;
using ControlCalidad.Aplicacion.Servicios.Turno.Interface;
using ControlCalidad.Dominio;
using ControlCalidad.Dominio.Entidades;
using ControlCalidad.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Color = ControlCalidad.Dominio.Entidades.Color;

namespace ControlCalidad.Presentacion.ViewModels
{
    public class IniciarOrdenProduccionViewModel : BaseViewModel
    {
        private IOrdenProduccionService _ordenProduccionService;
        private readonly ILineaTrabajoService _lineaTrabajoService;
        private readonly IColorService _colorService;
        private readonly IModeloService _modeloService;
        private readonly ITurnoService _turnoService;

        public IniciarOrdenProduccionViewModel(ILineaTrabajoService lineaTrabajoService,
            IOrdenProduccionService ordenProduccionService,
            IColorService colorService,
            IModeloService modeloService,
            ITurnoService turnoService)
        {
            _lineaTrabajoService = lineaTrabajoService;
            _ordenProduccionService = ordenProduccionService;
            _colorService = colorService;
            _modeloService = modeloService;
            _turnoService = turnoService;
            if (_turnoService.PuedeOperar(DateTime.Now.TimeOfDay) && !Settings.Default.Usuario.EstaAsignado)
                ActualizarListaLineas();
            else if (!_turnoService.PuedeOperar(DateTime.Now.TimeOfDay))
            {
                MostrarMensaje("Mensaje de advertencia", "El turno ya finalizó, la operación no se pudo realizar", "Aceptar");
            }
            else
            {
                MostrarMensaje("Mensaje de advertencia", "Usted ya se encuentra asignado a otra orden de producción.", "Aceptar");
            }

            SelectCommand = new Command(OnSelectCommand);
            IniciarCommand = new Command(OnIniciarCommand);
        }

        private void ActualizarListaLineas()
        {
            Lineas = new ObservableCollection<LineaTrabajo>(_lineaTrabajoService.LineasTrabajosVacias());
        }

        private ObservableCollection<LineaTrabajo> _lineas;
        public ObservableCollection<LineaTrabajo> Lineas
        {
            get { return _lineas; }
            set
            {
                _lineas = value;
                OnPropertyChanged("Lineas");
            }

        }

        private List<Color> _colores;
        public List<Color> Colores
        {
            get { return _colores; }
            set
            {
                _colores = value;
                OnPropertyChanged("Colores");
            }
        }

        private List<Modelo> _modelos;
        public List<Modelo> Modelos
        {
            get { return _modelos; }
            set
            {
                _modelos = value;
                OnPropertyChanged("Modelos");
            }
        }

        private LineaTrabajo _lineaTrabajo;
        public LineaTrabajo LineaTrabajo
        {
            get { return _lineaTrabajo; }
            set
            {
                _lineaTrabajo = value;
                OnPropertyChanged("LineaTrabajo");
            }
        }

        private OrdenProduccion _ordenProduccion;
        public OrdenProduccion OrdenProduccion
        {
            get { return _ordenProduccion; }
            set
            {
                _ordenProduccion = value;
                OnPropertyChanged("OrdenProduccion");
            }
        }

        public Modelo Modelo
        {
            get { return OrdenProduccion?.Modelo ?? null; }
            set
            {
                OrdenProduccion.Modelo = value;
                OnPropertyChanged("Modelo");
            }
        }

        public Color Color
        {
            get { return OrdenProduccion?.Color ?? null; }
            set
            {
                OrdenProduccion.Color = value;
                OnPropertyChanged("Color");
            }
        }

        public ICommand SelectCommand { get; set; }
        public ICommand IniciarCommand { get; set; }

        public void OnSelectCommand(object obj)
        {
            if (!(LineaTrabajo is null) && LineaTrabajo.NumeroLinea == (obj as LineaTrabajo).NumeroLinea)
                return;
            LineaTrabajo = obj as LineaTrabajo;
            LineaTrabajo.Supervisores.Add(Settings.Default.Usuario);
            Settings.Default.Usuario.LineasTrabajo.Add(LineaTrabajo);
            OrdenProduccion = new OrdenProduccion();
            Colores = _colorService.GetAllActives().ToList();
            Modelos = _modeloService.GetAllActives().ToList();
        }

        public void OnIniciarCommand(object obj)
        {
            //Duda: Aquí ya tengo OrdenProduccion con color y modelo, buscar de nuevo?
            var color = _colorService.GetById(Color.Id);
            var modelo = _modeloService.GetById(Modelo.Id);
            var op = new OrdenProduccion
            {
                Color = color,
                Modelo = modelo,
                Numero = OrdenProduccion.Numero,
                LineaTrabajo = LineaTrabajo,
                EstadoOrdenProduccion = Dominio.Enums.EstadoOrdenProduccion.EnProgreso
            };

            var lt = _lineaTrabajoService.GetById(LineaTrabajo.Id);
            if (lt.EstaLibre)
            {
                lt.OrdenesProduccion.Add(op);
                _lineaTrabajoService.AddOrUpdate(lt);
                _ordenProduccionService.AddOrUpdate(op);
                Settings.Default.Usuario.OrdenesProduccion.Add(op);
            }
            else
                throw new InvalidOperationException();
            GoHome();
        }
    }
}
