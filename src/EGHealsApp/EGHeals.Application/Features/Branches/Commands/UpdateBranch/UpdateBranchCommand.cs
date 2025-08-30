using EGHeals.Application.Dtos.Branches;

namespace EGHeals.Application.Features.Branches.Commands.UpdateBranch
{
    public record UpdateBranchCommand(UpdateBranchDto Branch) : ICommand<UpdateBranchResult>;
    public record UpdateBranchResult(bool IsSuccess);

    public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
    {
        public UpdateBranchCommandValidator()
        {
            RuleFor(x => x.Branch).NotNull().WithMessage("Error")
                                  .SetValidator(new UpdateBranchDtoValidator());
        }
    }

    public class UpdateBranchDtoValidator : AbstractValidator<UpdateBranchDto>
    {
        public UpdateBranchDtoValidator()
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
