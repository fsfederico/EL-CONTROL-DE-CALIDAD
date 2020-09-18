﻿using System.ComponentModel.DataAnnotations;

namespace ControlCalidad.Dominio.Enums
{
    public enum EstadoOrdenProduccion
    {
        Pausado,
        [Display(Name = "En progreso")]
        EnProgreso,
        Finalizado
    }
}
