using EGHeals.Application.Dtos.ReferralDoctors;

namespace EGHeals.Application.Features.ReferralDoctors.Commands.UpdateReferralDoctor
{
    public record UpdateReferralDoctorCommand(UpdateReferralDoctorDto ReferralDoctor) : ICommand<UpdateReferralDoctorResult>;
    public record UpdateReferralDoctorResult(bool IsSuccess);

    public class UpdateReferralDoctorCommandValidator : AbstractValidator<UpdateReferralDoctorCommand>
    {
        public UpdateReferralDoctorCommandValidator()
        {
            RuleFor(x => x.ReferralDoctor).NotNull().WithMessage("Error")
                                          .SetValidator(new UpdateReferralDoctorDtoValidator());
        }
    }

    public class UpdateReferralDoctorDtoValidator : AbstractValidator<UpdateReferralDoctorDto>
    {
        public UpdateReferralDoctorDtoValidator()
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
