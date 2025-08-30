using EGHeals.Application.Dtos.Users;

namespace EGHeals.Application.Features.Users.Commands.CreateUser
{
    public record CreateAdminUserCommand(CreateAdminUserDto User) : ICommand<CreateAdminUserResult>;
    public record CreateAdminUserResult(Guid Id);

    public class CreateAdminUserCommandValidator : AbstractValidator<CreateAdminUserCommand>
    {
        public CreateAdminUserCommandValidator()
        {
            RuleFor(x => x.User).NotNull().WithMessage("Error")
                                .SetValidator(new CreateAdminUserDtoValidator());
        }
    }

    public class CreateAdminUserDtoValidator : AbstractValidator<CreateAdminUserDto>
    {
        public CreateAdminUserDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Error")
                                    .NoWhitespacesAllowed("Error")
                                    .MaximumLength(150).WithMessage("Error")
                                    .MinimumLength(3).WithMessage("Error");

            RuleFor(x => x.Mobile).EgyptianMobile();

            RuleFor(x => x.Email).MaximumLength(150).WithMessage("Error")
                                 .MinimumLength(6).WithMessage("Error")
                                 .EmailAddress().WithMessage("Error");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Error")
                                    .NoWhitespacesAllowed("Error")
                                    .MaximumLength(50).WithMessage("Error")
                                    .MinimumLength(3).WithMessage("Error");            
        }
    }
}
