using System;
using System.Globalization;
using System.Windows.Controls;

namespace WpfApp1
{
    public class StringToNonNegativeDoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (!double.TryParse(value.ToString(), out double result))
                return new ValidationResult(false, "Not a valid number");

            if (result < 0)
                return new ValidationResult(false, "Number must be greater than or equal to 0");

            return new ValidationResult(true, null);
        }
    }
}
