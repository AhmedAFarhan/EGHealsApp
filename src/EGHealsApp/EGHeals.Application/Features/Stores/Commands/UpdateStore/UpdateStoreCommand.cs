using EGHeals.Application.Dtos.Stores;

namespace EGHeals.Application.Features.Stores.Commands.UpdateStore
{
    public record UpdateStoreCommand(UpdateStoreDto Store) : ICommand<UpdateStoreResult>;
    public record UpdateStoreResult(bool IsSuccess);

    public class UpdateStoreCommandValidator : AbstractValidator<UpdateStoreCommand>
    {
        public UpdateStoreCommandValidator()
        {
            RuleFor(x => x.Store).NotNull().WithMessage("Error")
                                 .SetValidator(new UpdateStoreDtoValidator());
        }
    }

    public class UpdateStoreDtoValidator : AbstractValidator<UpdateStoreDto>
    {
        public UpdateStoreDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Error")
                                .NotNullOrWhitespace("Error")
                                .MaximumLength(150).WithMessage("Error")
                                .MinimumLength(3).WithMessage("Error");

            RuleFor(x => x.BranchId).NotEmpty().WithMessage("Error")
                                    .NotNull().WithMessage("Error");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Error")
                                       .MaximumLength(250).WithMessage("Error")
                                       .MinimumLength(3).WithMessage("Error")
                                       .When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
}
