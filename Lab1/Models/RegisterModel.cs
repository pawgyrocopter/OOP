using System.ComponentModel.DataAnnotations;

namespace Lab1.Models;


public class RegisterModel : IValidatableObject
{
    [Required(ErrorMessage = "Не указан Email")]
    [Display(Name = "Email")]
    [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    [Required]
    public string SecondName { get; set; }
    [Required]
    public string SeriesAndPassportNumber { get; set; }
    [Required]
    public string IdentificationNumber { get; set; }
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Не указан пароль")]
    [DataType(DataType.Password)]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "min 6, max 30")]
    public string Password { get; set; }
 
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Пароль введен неверно")]
    public string ConfirmPassword { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new List<ValidationResult>();
        if (this.Password.Length < 5)
        {
            errors.Add(new ValidationResult("Password leng"));
        }
        if (this.PhoneNumber.Length < 5)
        {
            errors.Add(new ValidationResult("PhoneNumber leng"));
        }
        return errors;
    }
}