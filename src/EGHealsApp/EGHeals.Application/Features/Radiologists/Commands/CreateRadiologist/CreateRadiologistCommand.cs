using EGHeals.Application.Dtos.RadiologistDevices;
using EGHeals.Application.Dtos.RadiologistExaminationsCosts;
using EGHeals.Application.Dtos.Radiologists;
using EGHeals.Domain.Enums;

namespace EGHeals.Application.Features.Radiologists.Commands.CreateRadiologist
{
    public record CreateRadiologistCommand(CreateRadiologistDto Radiologist) : ICommand<CreateRadiologistResult>;
    public record CreateRadiologistResult(Guid Id);

    public class CreateRadiologistCommandValidator : AbstractValidator<CreateRadiologistCommand>
    {
        public CreateRadiologistCommandValidator()
        {
            RuleFor(x => x.Radiologist).NotNull().WithMessage("Error")
                                       .SetValidator(new CreateRadiologistDtoValidator());
        }
    }

    public class CreateRadiologistDtoValidator : AbstractValidator<CreateRadiologistDto>
    {
        public CreateRadiologistDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Error")
                                .NotNullOrWhitespace("Error")
                                .MaximumLength(150).WithMessage("Error")
                                .MinimumLength(3).WithMessage("Error");

            RuleFor(x => x.TeamWorkMemberId).NotEmpty().WithMessage("Error")
                                            .NotNull().WithMessage("Error");

            RuleForEach(x => x.RadiologistDevices).SetValidator(new RadiologistDeviceDtoValidator());

            RuleForEach(x => x.RadiologistExaminationCosts).SetValidator(new RadiologistExaminationCostDtoValidator());
        }
    }

    public class RadiologistDeviceDtoValidator : AbstractValidator<RadiologistDeviceDto>
    {
        public RadiologistDeviceDtoValidator()
        {
            RuleFor(x => x.RadiologistId).NotEmpty().WithMessage("Error")
                                         .NotNull().WithMessage("Error");

            RuleFor(x => x.RadiologyDevice).NotNull().WithMessage("Error")
                                           .Must(value => Enum.IsDefined(typeof(RadiologyDevice), value)).WithMessage("Error");
        }
    }

    public class RadiologistExaminationCostDtoValidator : AbstractValidator<RadiologistExaminationCostDto>
    {
        public RadiologistExaminationCostDtoValidator()
        {
            RuleFor(x => x.RadiologistId).NotEmpty().WithMessage("Error")
                                         .NotNull().WithMessage("Error");

            RuleFor(x => x.ExaminationId).NotEmpty().WithMessage("Error")
                                         .NotNull().WithMessage("Error");

            RuleFor(x => x.Cost).NotEmpty().WithMessage("Error")
                                .LessThan(0).WithMessage("Error");
        }
    }
}
