using System.ComponentModel.DataAnnotations;
using ModelValidationsExample.CustomValidators;

namespace ModelValidationsExample.Models
{
  public class Person
  {
    [Required(ErrorMessage = "No {0}????")]
    [Display(Name = "Person name")]
    [StringLength(5)]

    public string? PersonName { get; set; }

    public string? Email { get; set; }
    public string? Phone { get; set; }
    [Compare("ConfirmPassword", ErrorMessage = "{0} do not match {1}")]
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    [Range(0, 10, ErrorMessage = "{0} should be between {1} and {2} ")]
    public double? Price { get; set; }

    [MinimumYearValidatorAttribute(2001)]
    [DateRangeValidatorAttribute("DateOfDeath")]
    public DateTime DateOfBirth { get; set; }
    public DateTime DateOfDeath { get; set; }

    public override string ToString()
    {
      return $"Person object - Person name: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
    }
  }
}
