namespace ControlCalidad.Dominio.Entidades
{
    public class CantidadDefecto : EntityBase
    {
        public int CantidadIzquierdo { get; set; }
        public int CantidadDerecho { get; set; }

        public virtual Defecto Defecto { get; set; }
        public virtual InspeccionOrdenProduccion InspeccionOrdenProduccion { get; set; }
    }
}
