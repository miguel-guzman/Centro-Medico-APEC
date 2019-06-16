using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjHospital.Models
{
  public class ActividadModel
  {
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string Nombre { get; set; }
  }
}