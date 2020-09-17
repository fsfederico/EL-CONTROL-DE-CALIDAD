using ControlCalidad.Dominio.Entidades;

namespace ControlCalidad.Presentacion
{
    public class Settings
    {
        // this is the default static instance you'd use like string text = Settings.Default.SomeSetting;
        public readonly static Settings Default = new Settings();

        public Usuario Usuario { get; set; } // add setting properties as you wish
    }
}
