using System.ComponentModel.DataAnnotations;

namespace aspNetEssencial.Validations
{
    public class FirstLetter: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
         ValidationContext validationContext)
         {
             if(value == null || string.IsNullOrEmpty(value.ToString()))
             {
                 return ValidationResult.Success;
             }

             var firstLetter = value.ToString()[0].ToString();
             if(firstLetter != firstLetter.ToUpper())
             {
                 return new ValidationResult("The first letter should be in CapsLock!");
             }

             return ValidationResult.Success;
         }
    }
}
