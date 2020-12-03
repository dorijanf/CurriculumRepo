using CurriculumRepository.CORE.Data.Models.Scenario;
using FluentValidation;

namespace CurriculumRepository.CORE.Data.Validators.Scenario
{
    public class CreateLsValidator : AbstractValidator<LsBM>
    {
        public CreateLsValidator()
        {
            #region Name & Description
            RuleFor(x => x.Lsname).NotEmpty()
                .WithMessage("Activity name is required.");
            RuleFor(x => x.Lsname).Must(ValidationHelpers.NotContainSpecial)
                .WithMessage("Name can not have special characters.");
            RuleFor(x => x.Lsname).MinimumLength(3)
                .WithMessage("Scenario name must be at least 3 characters long.");
            RuleFor(x => x.Lsname).MaximumLength(14)
                .WithMessage("Scenario name must be at least 14 characters long.");
            RuleFor(x => x.Lsdescription).MaximumLength(800)
                .WithMessage("Scenario description can have a maximum of 400 characters.");
            #endregion

            #region LsTypeId
            RuleFor(x => x.LsTypeId).NotNull()
                .WithMessage("Type of scenario is required.");
            RuleFor(x => x.LsTypeId).InclusiveBetween(0,1)
                .WithMessage("Type can only be private or public.");
            #endregion

            #region LsGrade
            RuleFor(x => x.Lsgrade).NotNull()
                .WithMessage("Scenario grade is required.");
            RuleFor(x => x.Lsgrade).InclusiveBetween(1, 8)
                .WithMessage("Grade must be a value between 1 and 8 (inclusive).");
            #endregion
        }
    }
}
