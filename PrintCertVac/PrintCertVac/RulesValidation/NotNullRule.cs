using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PrintCertVac
{
    public class NotNullRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (string.IsNullOrWhiteSpace(charString))
                return new ValidationResult(false, $"Строка не должна быть пустой");

            return new ValidationResult(true, null);
        }
    }

    public class NotNullEngRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (string.IsNullOrWhiteSpace(charString))
                return new ValidationResult(false, $"Строка не должна быть пустой");

            string pattern = @"[a-zA-Z\d]";
            if (Regex.IsMatch(charString, pattern))
                return new ValidationResult(false, $"Строка содержит недопустимые символы");

            return new ValidationResult(true, null);
        }
    }

    public class NotNullRusRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (string.IsNullOrWhiteSpace(charString))
                return new ValidationResult(false, $"Строка не должна быть пустой");

            string pattern = @"[а-яА-Я\d]";
            if (Regex.IsMatch(charString, pattern))
                return new ValidationResult(false, $"Строка содержит недопустимые символы");

            return new ValidationResult(true, null);
        }
    }

    public class DateVacRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (string.IsNullOrWhiteSpace(charString))
                return new ValidationResult(false, $"Строка не должна быть пустой");

            if (charString.Length > 10 && !DateTime.TryParse(charString, out _))
                return new ValidationResult(false, $"Не верный формат даты");

            if (charString.Length < 8)
                return new ValidationResult(false, $"Не верный формат даты");

            return new ValidationResult(true, null);
        }
    }
}
