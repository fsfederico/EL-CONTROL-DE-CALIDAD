using System.ComponentModel.DataAnnotations;

namespace ControlCalidad.Dominio
{
    public enum Rol
    {
        [Display(Name = "Supervisor de línea")]
        SupervisorLinea,
        [Display(Name = "Supervisor de calidad")]
        SupervisorCalidad,
        Administrador
    }
}
