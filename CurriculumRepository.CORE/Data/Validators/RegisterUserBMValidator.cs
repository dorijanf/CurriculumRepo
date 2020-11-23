using CurriculumRepository.API.Models;
using CurriculumRepository.CORE.Data.Models;
using FluentValidation;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CurriculumRepository.CORE.Data.Validators
{
    public class RegisterUserBMValidator : AbstractValidator<RegisterUserBM>
    {
        public RegisterUserBMValidator()
        {
            #region FirstLastName
            RuleFor(x => x.Firstname).NotEmpty()
                .WithMessage("First name is required.");
            RuleFor(x => x.Lastname).NotEmpty()
                .WithMessage("Last name is required.");
            #endregion

            #region Username
            RuleFor(x => x.Username).NotEmpty()
                .WithMessage("Username is required");
            RuleFor(x => x.Username).MinimumLength(5)
                .WithMessage("Username must be at least 5 characters long.");
            RuleFor(x => x.Username).MaximumLength(14)
                .WithMessage("Username can not be longer than 14 characters.");
            #endregion

            #region Email
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage("Email must be in the correct format.");
            RuleFor(x => x.Email).NotNull()
                .WithMessage("Email is required.");
            #endregion

            #region Password
            RuleFor(x => x.Password).MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.");
            RuleFor(x => x.Password).Must(ValidationHelpers.ContainLowercase)
                .WithMessage("Password must contain at least one lowercase letter.");
            RuleFor(x => x.Password).Must(ValidationHelpers.ContainUppercase)
                .WithMessage("Password must contain at least one uppercase letter.");
            RuleFor(x => x.Password).Must(ValidationHelpers.ContainNumber)
                .WithMessage("Password must contain at least one number.");
            RuleFor(x => x.Password).Must(ValidationHelpers.ContainSpecial)
                .WithMessage("Password must contain at least one special character.");
            #endregion
        }
    }
}
