using CurriculumRepository.CORE.Data.Models;
using CurriculumRepository.CORE.Data.Models.Account;
using FluentValidation;

namespace CurriculumRepository.CORE.Data.Validators.Account
{
    public class AuthenticateUserDTOValidator : AbstractValidator<AuthenticateUserDTO>
    {
        public AuthenticateUserDTOValidator()
        {
            RuleFor(x => x.Username).NotEmpty()
                .WithMessage("Username is required.");
            RuleFor(x => x.Username).NotNull()
                .WithMessage("Username is required.");
            RuleFor(x => x.Password).NotNull()
                .WithMessage("Password is required.");
            RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Password is required.");
        }
    }
}
