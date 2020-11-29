using CurriculumRepository.CORE.Data.Models;
using CurriculumRepository.CORE.Data.Models.Account;
using FluentValidation;
namespace CurriculumRepository.CORE.Data.Validators.Account
{
    public class UpdateUserBMValidator : AbstractValidator<UpdateUserBM>
    {
        public UpdateUserBMValidator()
        {
            #region Email
            Unless(x => string.IsNullOrEmpty(x.Email), () =>
            {
                RuleFor(x => x.Email).EmailAddress()
                    .WithMessage("Email must be in the correct format.");
            });
            #endregion

            #region Password
            Unless(x => string.IsNullOrEmpty(x.Password), () => {
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
            });
            #endregion
        }
    }
}
