using System.ComponentModel.DataAnnotations;

namespace TreinamentoBenner.ValidationAnnotation
{
    public class MaxWordAttribute : ValidationAttribute
    {
        private readonly int _maxWords;

        public MaxWordAttribute(int maxWords)
            : base("{0} tem muitas palavras.")
        {
            _maxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length > _maxWords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}