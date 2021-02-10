using System;
using System.Globalization;
using System.Windows.Controls;
using System.Linq;

namespace DesktopClock
{
    class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string str)
            {
                if (! Double.TryParse(str, out _))
                {
                    return new ValidationResult(false, "Invalid character.");
                }
                else if (String.IsNullOrEmpty(str))
                {
                    return new ValidationResult(false, "Value is empty.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            return new ValidationResult(false, "Value is not string.");
        }
    }
}
