using EGHeals.Application.Dtos.Allowances;

namespace EGHeals.Application.Features.Allowances.Commands.UpdateAllowance
{
    public record UpdateAllowanceCommand(UpdateAllowanceDto allowance) : ICommand<UpdateAllowanceResult>;
    public record UpdateAllowanceResult(bool IsSuccess);

    public class UpdateAllowanceCommandValidator : AbstractValidator<UpdateAllowanceCommand>
    {
        public UpdateAllowanceCommandValidator()
        {
            RuleFor(x => x.allowance).NotNull().WithMessage("Error")
                                     .SetValidator(new UpdateAllowanceDtoValidator());
        }
    }

    public class UpdateAllowanceDtoValidator : AbstractValidator<UpdateAllowanceDto>
    {
        public UpdateAllowanceDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Error")
                                .NotNullOrWhitespace("Error")
                                .MaximumLength(150).WithMessage("Error")
                                .MinimumLength(3).WithMessage("Error");

            RuleFor(x => x.Cost).NotEmpty().WithMessage("Error")
                                .LessThan(0).WithMessage("Error");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Error")
                                       .MaximumLength(250).WithMessage("Error")
                                       .MinimumLength(3).WithMessage("Error")
                                       .When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
}
