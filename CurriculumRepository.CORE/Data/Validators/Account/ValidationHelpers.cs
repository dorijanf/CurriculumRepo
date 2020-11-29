using System.Linq;
using System.Linq.Dynamic.Core;

namespace CurriculumRepository.CORE.Data.Validators.Account
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
    }
}
