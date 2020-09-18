using ControlCalidad.Dominio;
using ControlCalidad.Dominio.Entidades;
using System.ComponentModel;

namespace ControlCalidad.Presentacion
{
    public class Settings : INotifyPropertyChanged
    {
        // this is the default static instance you'd use like string text = Settings.Default.SomeSetting;
        public readonly static Settings Default = new Settings();

        // add setting properties as you wish
        private Usuario _usuario;
        public Usuario Usuario
        {
            get { return _usuario; }
            set
            {
                //Notify the ShadowColorProperty Changed
                _usuario = value;
                OnNotifyPropertyChanged("Usuario");
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public bool IsInRole(Rol role)
        {
            return Usuario.Rol == role;
        }

    }

}
