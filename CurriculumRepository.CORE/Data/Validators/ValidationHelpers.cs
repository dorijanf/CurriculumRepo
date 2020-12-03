using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace CurriculumRepository.CORE.Data.Validators
{
    public static class ValidationHelpers
    {
        public static bool ContainLowercase(string password)
        {
            return password.Any(ch => char.IsLower(ch));
        }

        public static bool ContainUppercase(string password)
        {
            return password.Any(ch => char.IsUpper(ch));
        }

        public static bool ContainNumber(string password)
        {
            return password.Any(ch => char.IsDigit(ch));
        }

        public static bool ContainSpecial(string password)
        {
            return password.Any(ch => !char.IsLetterOrDigit(ch));
        }

        public static bool NotContainSpecial(string password)
        {
            return !password.Any(ch => !char.IsLetterOrDigit(ch));
        }
        public static bool GreaterThan1Minute(TimeSpan duration)
        {
            return duration.TotalMinutes >= 1;
        }
        public static bool LesserThan120Minutes(TimeSpan duration)
        {
            return duration.TotalMinutes <= 120;
        }
    }
}
