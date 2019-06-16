using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjHospital.DataAnnotations
{
  public class ExpectedHumanLifespan : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (value != null)
      {
        if ((DateTime)value < DateTime.Now.AddYears(-125))
        {
          return new ValidationResult(ErrorMessage ?? "Must not contain a date before 125 years ago");
        }
        if ((DateTime)value > DateTime.Now)
        {
          return new ValidationResult(ErrorMessage ?? "Must not contain a date later than today's date");
        }
        return ValidationResult.Success;
      }
      return ValidationResult.Success;
    }
  }
}
