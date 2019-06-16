using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using prjHospital.DataAnnotations;
using prjHospital.Helpers;

namespace prjHospital.Models
{
  public class PersonaModel
  {
    [Display(Name = "#")]
    public int Id { get; set; }

    [Required(
      ErrorMessage = "\"Nombres\" no puede estar vacío.")]
    [StringLength(60,
      ErrorMessage = "\"Nombres\" debe tener 60 caracteres o menos.")]
    public string Nombres { get; set; }

    [Required(
      ErrorMessage = "\"Apellido Paterno\" no puede estar vacío.")]
    [StringLength(30,
      ErrorMessage = "\"Apellido paterno\" debe tener 30 caracteres o menos.")]
    [Display(Name = "Apellido Paterno")]
    public string ApellidoPaterno { get; set; }

    [StringLength(30,
      ErrorMessage = "\"Apellido Materno\" debe tener 30 caracteres o menos.")]
    [Display(Name = "Apellido Materno")]
    public string ApellidoMaterno { get; set; }

    [Required(
      ErrorMessage = "\"Cédula de Identidad\" no puede estar vacío.")]
    [RegularExpression(@"([0-9]{11})",
      ErrorMessage = "\"Cédula de Identidad\" debe tener 11 dígitos.")]
    [Display(Name = "Cédula de Identidad")]
    public string CedulaIdentidad { get; set; }

    [Required(
      ErrorMessage = "\"Fecha de Nacimiento\" no puede estar vacío.")]
    [DataType(DataType.Date)]
    [ExpectedHumanLifespan(
      ErrorMessage = "\"Fecha de Nacimiento\" no puede ser posterior al día de hoy.")]
    [Display(Name = "Fecha de Nacimiento")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaNacimiento { get; set; }

    [Required(ErrorMessage = "\"Sexo\" no puede estar vacío.")]
    public int SexoId { get; set; }
    public virtual SexoModel Sexo { get; set; }

    public string NombreCompleto
    {
      get
      {
        return Nombres + " " + ApellidoPaterno + " " + ApellidoMaterno;
      }
    }
    public string Edad
    {
      get
      {
        DateDifference dateDifference = new DateDifference(FechaNacimiento, DateTime.Now);
        if (dateDifference.Years > 0)
        {
          return dateDifference.Years + (dateDifference.Years > 1 ? " años" : " año");
        }
        else
        {
          if (dateDifference.Months > 0)
          {
            return dateDifference.Months + (dateDifference.Months > 1 ? " meses" : " mes");
          }
          else
          {
            return dateDifference.Days + (dateDifference.Days == 1 ? " día" : " días");
          }
        }
      }
    }
  }
}