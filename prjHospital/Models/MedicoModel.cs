using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjHospital.Models
{
  public class MedicoModel
  {
    public int Id { get; set; }

    [Required]
    public virtual PersonaModel Persona { get; set; }

    public IList<ActividadEspecialidadModel> ActividadEspecialidad { get; set; }
  }
}