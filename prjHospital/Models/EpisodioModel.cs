using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjHospital.Models
{
  public class EpisodioModel
  {
    public int Id { get; set; }

    [Required]
    public virtual ActividadModel Actividad { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
    [Display(Name = "Fecha y Hora de Ingreso")]
    public DateTime FechaHoraIngreso { get; set; } = DateTime.Now;

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
    [Display(Name = "Tipo de Ingreso")]
    public virtual TipoIngresoModel TipoIngreso { get; set; }

    [Display(Name = "Fecha y Hora de Egreso")]
    public DateTime FechaHoraEgreso { get; set; }

    [Display(Name = "Tipo de Egreso")]
    public virtual TipoEgresoModel TipoEgreso { get; set; }

    [Required]
    public virtual PersonaModel Persona { get; set; }

    [Required]
    [Display(Name = "Médico")]
    public virtual MedicoModel Medico { get; set; }

  }
}