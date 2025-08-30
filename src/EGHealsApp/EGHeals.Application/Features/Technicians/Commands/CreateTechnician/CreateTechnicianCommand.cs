using EGHeals.Application.Dtos.TechnicianDevices;
using EGHeals.Application.Dtos.TechnicianExaminationCosts;
using EGHeals.Application.Dtos.Technicians;
using EGHeals.Domain.Enums;

namespace EGHeals.Application.Features.Technicians.Commands.CreateTechnician
{
    public record CreateTechnicianCommand(CreateTechnicianDto Technician) : ICommand<CreateTechnicianResult>;
    public record CreateTechnicianResult(Guid Id);

    public class CreateTechnicianCommandValidator : AbstractValidator<CreateTechnicianCommand>
    {
        public CreateTechnicianCommandValidator()
        {
            RuleFor(x => x.Technician).NotNull().WithMessage("Error")
                                      .SetValidator(new CreateTechnicianDtoValidator());

        }
    }

    public class CreateTechnicianDtoValidator : AbstractValidator<CreateTechnicianDto>
    {
        public CreateTechnicianDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Error")
                                .NotNullOrWhitespace("Error")
                                .MaximumLength(150).WithMessage("Error")
                                .MinimumLength(3).WithMessage("Error");

            RuleFor(x => x.TeamWorkMemberId).NotEmpty().WithMessage("Error")
                                            .NotNull().WithMessage("Error");

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
