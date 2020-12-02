using ControlCalidad.Dominio.Enums;

namespace ControlCalidad.Dominio
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public Estado Estado { get; set; }

        public void Eliminar()
        {
            this.Estado = Estado.Eliminado;
        }
    }
}
