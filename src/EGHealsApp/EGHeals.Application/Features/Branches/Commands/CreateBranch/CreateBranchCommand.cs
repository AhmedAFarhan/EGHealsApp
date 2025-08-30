using EGHeals.Application.Dtos.Branches;

namespace EGHeals.Application.Features.Branches.Commands.CreateBranch
{
    public record CreateBranchCommand(CreateBranchDto Branch) : ICommand<CreateBranchResult>;
    public record CreateBranchResult(Guid Id);

    public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchCommandValidator()
        {
            RuleFor(x => x.Branch).NotNull().WithMessage("Error")
                                  .SetValidator(new CreateBranchDtoValidator());
        }
    }

    public class CreateBranchDtoValidator : AbstractValidator<CreateBranchDto>
    {
        public CreateBranchDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Error")
                                .NotNullOrWhitespace("Error")
                                .MaximumLength(150).WithMessage("Error")
                                .MinimumLength(3).WithMessage("Error");

            RuleFor(x => x.Latitude).NotEmpty().WithMessage("Error");

            RuleFor(x => x.Longitude).NotEmpty().WithMessage("Error");

            RuleFor(x => x.HowToReach).NotEmpty().WithMessage("Error")
                                      .MaximumLength(250).WithMessage("Error")
                                      .MinimumLength(3).WithMessage("Error")
                                      .When(x => !string.IsNullOrEmpty(x.HowToReach));
        }
    }
}

