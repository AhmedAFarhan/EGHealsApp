using EGHeals.Application.Dtos.ReferralDoctors;

namespace EGHeals.Application.Features.ReferralDoctors.Commands.CreateReferralDoctor
{
    public record CreateReferralDoctorCommand(CreateReferralDoctorDto ReferralDoctor) : ICommand<CreateReferralDoctorResult>;
    public record CreateReferralDoctorResult(Guid Id);

    public class CreateReferralDoctorCommandValidator : AbstractValidator<CreateReferralDoctorCommand>
    {
        public CreateReferralDoctorCommandValidator()
        {
            RuleFor(x => x.ReferralDoctor).NotNull().WithMessage("Error")
                                          .SetValidator(new CreateReferralDoctorDtoValidator());
        }
    }

    public class CreateReferralDoctorDtoValidator : AbstractValidator<CreateReferralDoctorDto>
    {
        public CreateReferralDoctorDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Error")
                                    .NotNullOrWhitespace("Error")
                                    .MaximumLength(150).WithMessage("Error")
                                    .MinimumLength(3).WithMessage("Error");

            RuleFor(x => x.NationalId).NotEmpty().WithMessage("Error")
                                      .Length(11).WithMessage("Error")
                                      .When(x => !string.IsNullOrEmpty(x.NationalId));

            RuleFor(x => x.Mobile).EgyptianMobile();
        }
    }
}
