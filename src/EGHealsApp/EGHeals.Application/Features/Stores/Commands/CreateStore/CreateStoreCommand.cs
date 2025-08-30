using EGHeals.Application.Dtos.Stores;

namespace EGHeals.Application.Features.Stores.Commands.CreateStore
{
    public record CreateStoreCommand(CreateStoreDto Store) : ICommand<CreateStoreResult>;
    public record CreateStoreResult(Guid Id);

    public class CreateStoreCommandValidator : AbstractValidator<CreateStoreCommand>
    {
        public CreateStoreCommandValidator()
        {
            RuleFor(x => x.Store).NotNull().WithMessage("Error")
                                 .SetValidator(new CreateStoreDtoValidator());
        }
    }

    public class CreateStoreDtoValidator : AbstractValidator<CreateStoreDto>
    {
        public CreateStoreDtoValidator()
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
