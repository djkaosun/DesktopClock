using System;
using System.Globalization;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClock
{
    class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string str)
            {
                if (str.Any(c => !char.IsNumber(c)))
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
