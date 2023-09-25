using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.Filters
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NotEqualAttribute : ValidationAttribute
    {
        private readonly string _targetProperty;

        public NotEqualAttribute(string targetProperty)
        {
            _targetProperty = targetProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyValue = validationContext.ObjectType.GetProperty(_targetProperty).GetValue(validationContext.ObjectInstance, null);

            if (value != null && value.Equals(otherPropertyValue))
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} must not be the same as {_targetProperty}.");
            }

            return ValidationResult.Success;
        }
    }
}
