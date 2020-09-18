using ControlCalidad.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ControlCalidad.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Rol
        private bool _esAdministrador;
        public bool EsAdministrador
        {
            get
            {
                return _esAdministrador;
            }
            set
            {
                _esAdministrador = value;
                OnPropertyChanged("EsAdministrador");
            }
        }

        private bool _esSupervisorLinea;
        public bool EsSupervisorLinea
        {
            get
            {
                return _esSupervisorLinea;
            }
            set
            {
                _esSupervisorLinea = value;
                OnPropertyChanged("EsSupervisorLinea");
            }
        }

        private bool _esSupervisorCalidad;
        public bool EsSupervisorCalidad
        {
            get
            {
                return _esSupervisorCalidad;
            }
            set
            {
                _esSupervisorCalidad = value;
                OnPropertyChanged("EsSupervisorLinea");
            }
        }
        #endregion

        public BaseViewModel()
        {
            Settings.Default.PropertyChanged += UserChange;
            EstablecerFuncionalidades();
        }

        private void EstablecerFuncionalidades()
        {
            EsAdministrador = Settings.Default.IsInRole(Dominio.Rol.Administrador);
            EsSupervisorCalidad = Settings.Default.IsInRole(Dominio.Rol.SupervisorCalidad);
            EsSupervisorLinea = Settings.Default.IsInRole(Dominio.Rol.SupervisorLinea);
        }

        private void UserChange(object o, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Usuario")
            {
                EstablecerFuncionalidades();
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
