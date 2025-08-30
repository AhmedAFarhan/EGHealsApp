using EGHeals.Application.Dtos.Patients;
using EGHeals.Domain.Enums;

namespace EGHeals.Application.Features.Patients.Commands.CreatePatient
{
    public record CreatePatientCommand(CreatePatientDto Patient) : ICommand<CreatePatientResult>;
    public record CreatePatientResult(Guid Id);

    public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator()
        {
            RuleFor(x => x.Patient).NotNull().WithMessage("Error")
                                   .SetValidator(new CreatePatientDtoValidator());
        }
    }

    public class CreatePatientDtoValidator : AbstractValidator<CreatePatientDto>
    {
        public CreatePatientDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Error")
                                    .NotNullOrWhitespace("Error")
                                    .MaximumLength(150).WithMessage("Error")
                                    .MinimumLength(3).WithMessage("Error");

            RuleFor(x => x.NationalId).NotEmpty().WithMessage("Error")
                                     .Length(11).WithMessage("Error")
                                     .When(x => !string.IsNullOrEmpty(x.NationalId));

            RuleFor(x => x.Mobile).EgyptianMobile(isOptional: true);

            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Error")
                                       .NotNull().WithMessage("Error");

            RuleFor(x => x.Gender).NotNull().WithMessage("Error")
                                  .Must(value => Enum.IsDefined(typeof(Gender), value)).WithMessage("Error");

            RuleFor(x => x.GuardianId).NotEmpty().WithMessage("Error");

        }
    }
}
