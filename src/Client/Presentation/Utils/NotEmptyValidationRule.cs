using System.Globalization;
using System.Windows.Controls;

namespace Presentation.Utils
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Campo requerido.")
                : ValidationResult.ValidResult;
        }
    }
}
