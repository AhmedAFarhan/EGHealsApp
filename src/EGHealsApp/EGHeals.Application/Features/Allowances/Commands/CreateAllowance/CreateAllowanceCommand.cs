using EGHeals.Application.Dtos.Allowances;

namespace EGHeals.Application.Features.Allowances.Commands.CreateAllowance
{
    public record CreateAllowanceCommand(CreateAllowanceDto allowance) : ICommand<CreateAllowanceResult>;
    public record CreateAllowanceResult(Guid Id);

    public class CreateAllowanceCommandValidator : AbstractValidator<CreateAllowanceCommand>
    {
        public CreateAllowanceCommandValidator()
        {
            RuleFor(x => x.allowance).NotNull().WithMessage("Error")
                                     .SetValidator(new CreateAllowanceDtoValidator());
        }
    }

    public class CreateAllowanceDtoValidator : AbstractValidator<CreateAllowanceDto>
    {
        public CreateAllowanceDtoValidator()
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
