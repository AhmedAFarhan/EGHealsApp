using EGHeals.Application.Dtos.Patients;
using EGHeals.Domain.Enums;

namespace EGHeals.Application.Features.Patients.Commands.UpdatePatient
{
    public record UpdatePatientCommand(UpdatePatientDto Patient) : ICommand<UpdatePatientResult>;
    public record UpdatePatientResult(bool IsSuccess);

    public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidator()
        {
            RuleFor(x => x.Patient).NotNull().WithMessage("Error")
                                   .SetValidator(new UpdatePatientDtoValidator());
        }
    }

    public class UpdatePatientDtoValidator : AbstractValidator<UpdatePatientDto>
    {
        public UpdatePatientDtoValidator()
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
        }
    }
}

