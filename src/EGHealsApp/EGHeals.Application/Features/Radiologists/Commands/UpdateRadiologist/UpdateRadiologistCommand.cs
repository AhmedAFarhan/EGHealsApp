using EGHeals.Application.Dtos.RadiologistDevices;
using EGHeals.Application.Dtos.RadiologistExaminationsCosts;
using EGHeals.Application.Dtos.Radiologists;
using EGHeals.Domain.Enums;

namespace EGHeals.Application.Features.Radiologists.Commands.UpdateRadiologist
{
    public record UpdateRadiologistCommand(UpdateRadiologistDto Radiologist) : ICommand<UpdateRadiologistResult>;
    public record UpdateRadiologistResult(bool IsSuccess);

    public class UpdateRadiologistCommandValidator : AbstractValidator<UpdateRadiologistCommand>
    {
        public UpdateRadiologistCommandValidator()
        {
            RuleFor(x => x.Radiologist).NotNull().WithMessage("Error")
                                       .SetValidator(new UpdateRadiologistDtoValidator());
        }
    }

    public class UpdateRadiologistDtoValidator : AbstractValidator<UpdateRadiologistDto>
    {
        public UpdateRadiologistDtoValidator()
        {
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
