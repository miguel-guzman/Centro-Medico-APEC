using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjHospital.Models
{
  public class ActividadEspecialidadModel
  {
    public int Id { get; set; }

    [Required]
    public virtual ActividadModel Actividad { get; set; }

    [Required]
    public virtual EspecialidadModel Especialidad { get; set; }
  }
}