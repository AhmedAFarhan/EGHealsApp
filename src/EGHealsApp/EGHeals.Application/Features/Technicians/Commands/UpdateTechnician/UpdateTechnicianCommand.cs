using EGHeals.Application.Dtos.TechnicianDevices;
using EGHeals.Application.Dtos.TechnicianExaminationCosts;
using EGHeals.Application.Dtos.Technicians;
using EGHeals.Domain.Enums;

namespace EGHeals.Application.Features.Technicians.Commands.UpdateTechnician
{
    public record UpdateTechnicianCommand(UpdateTechnicianDto Technician) : ICommand<UpdateTechnicianResult>;
    public record UpdateTechnicianResult(bool IsSuccess);

    public class UpdateTechnicianCommandValidator : AbstractValidator<UpdateTechnicianCommand>
    {
        public UpdateTechnicianCommandValidator()
        {
            RuleFor(x => x.Technician).NotNull().WithMessage("Error")
                                      .SetValidator(new UpdateTechnicianDtoValidator());

        }
    }

    public class UpdateTechnicianDtoValidator : AbstractValidator<UpdateTechnicianDto>
    {
        public UpdateTechnicianDtoValidator()
        {
            RuleForEach(x => x.TechnicianDevices).SetValidator(new TechnicianDeviceDtoValidator());

            RuleForEach(x => x.TechnicianExaminationCosts).SetValidator(new TechnicianExaminationCostDtoValidator());
        }
    }

    public class TechnicianDeviceDtoValidator : AbstractValidator<TechnicianDeviceDto>
    {
        public TechnicianDeviceDtoValidator()
        {
            RuleFor(x => x.TechnicianId).NotEmpty().WithMessage("Error")
                                        .NotNull().WithMessage("Error");

            RuleFor(x => x.RadiologyDevice).NotNull().WithMessage("Error")
                                           .Must(value => Enum.IsDefined(typeof(RadiologyDevice), value)).WithMessage("Error");
        }
    }

    public class TechnicianExaminationCostDtoValidator : AbstractValidator<TechnicianExaminationCostDto>
    {
        public TechnicianExaminationCostDtoValidator()
        {
            RuleFor(x => x.TechnicianId).NotEmpty().WithMessage("Error")
                                        .NotNull().WithMessage("Error");

            RuleFor(x => x.ExaminationId).NotEmpty().WithMessage("Error")
                                         .NotNull().WithMessage("Error");

            RuleFor(x => x.Cost).NotEmpty().WithMessage("Error")
                                .LessThan(0).WithMessage("Error");
        }
    }
}
