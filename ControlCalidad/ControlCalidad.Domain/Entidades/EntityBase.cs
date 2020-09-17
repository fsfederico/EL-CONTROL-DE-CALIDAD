using ControlCalidad.Dominio.Enums;

namespace ControlCalidad.Dominio.Entidades
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public Estado Estado { get; set; }
    }
}
