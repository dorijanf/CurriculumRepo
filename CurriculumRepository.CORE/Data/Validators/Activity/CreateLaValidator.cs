using CurriculumRepository.CORE.Data.Models.Activity;
using FluentValidation;

namespace CurriculumRepository.CORE.Data.Validators.Scenario
{
    public class CreateLaValidator : AbstractValidator<LaBM>
    {
        public CreateLaValidator()
        {
            #region OrdinalNumber, Performance, Type
            RuleFor(x => x.OrdinalNumber).NotEmpty()
                .WithMessage("Ordinal number is required.");
            RuleFor(x => x.OrdinalNumber).InclusiveBetween(0, 100)
                .WithMessage("Ordinal number must have a value between 0 and 100 (inclusive).");
            RuleFor(x => x.PerformanceId).NotNull()
                .WithMessage("Performance must be set.");
            RuleFor(x => x.LatypeId).NotNull()
                .WithMessage("Activity must have a type.");
            #endregion

            #region Name, Duration, Description
            RuleFor(x => x.Laname).NotEmpty()
                .WithMessage("Activity name is required.");
            RuleFor(x => x.Laname).Must(ValidationHelpers.NotContainSpecial)
                .WithMessage("Activity name can not have special characters.");
            RuleFor(x => x.Laname).MinimumLength(3)
                .WithMessage("Activity name must be at least 3 characters long.");
            RuleFor(x => x.Laname).MaximumLength(14)
                .WithMessage("Activity name must be at least 14 characters long.");
            RuleFor(x => x.Ladescription).MaximumLength(800)
                .WithMessage("Activity description can have a maximum of 400 characters.");
            RuleFor(x => x.Laduration).Must(ValidationHelpers.GreaterThan1Minute)
                .WithMessage("Activity duration must be equal to or greater than one minute.");
            RuleFor(x => x.Laduration).Must(ValidationHelpers.LesserThan120Minutes)
                .WithMessage("Activity duration must be lesser than or equal to 120 minutes");
            #endregion
        }
    }
}
