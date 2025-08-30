using EGHeals.Application.Dtos.Users;

namespace EGHeals.Application.Features.Users.Commands.CreateUser
{
    public record CreateSubUserCommand(CreateSubUserDto User) : ICommand<CreateSubUserResult>;
    public record CreateSubUserResult(Guid Id);

    public class CreateSubUserCommandValidator : AbstractValidator<CreateSubUserCommand>
    {
        public CreateSubUserCommandValidator()
        {
            RuleFor(x => x.User).NotNull().WithMessage("")
                                .SetValidator(new CreateSubUserDtoValidator());
        }
    }

    public class CreateSubUserDtoValidator : AbstractValidator<CreateSubUserDto>
    {
        public CreateSubUserDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Error")
                                    .NoWhitespacesAllowed("Error")
                                    .MaximumLength(150).WithMessage("Error")
                                    .MinimumLength(3).WithMessage("Error");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Error")
                                    .NoWhitespacesAllowed("Error")
                                    .MaximumLength(50).WithMessage("Error")
                                    .MinimumLength(3).WithMessage("Error");

            RuleFor(x => x.AdminId).NotEmpty().WithMessage("Error")
                                   .NotNull().WithMessage("Error");

            RuleForEach(x => x.UserRoles).SetValidator(new CreateUserRoleDtoValidator());
        }
    }

    public class CreateUserRoleDtoValidator : AbstractValidator<CreateUserRoleDto>
    {
        public CreateUserRoleDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Error")
                                  .NotNull().WithMessage("Error");

            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Error")
                                  .NotNull().WithMessage("Error");

            RuleForEach(x => x.UserRolePermissions).SetValidator(new CreateUserRolePermissionDtoValidator());
        }
    }

    public class CreateUserRolePermissionDtoValidator : AbstractValidator<CreateUserRolePermissionDto>
    {
        public CreateUserRolePermissionDtoValidator()
        {
            RuleFor(x => x.UserRoleId).NotEmpty().WithMessage("Error")
                                      .NotNull().WithMessage("Error");

            RuleFor(x => x.RolePermissionId).NotEmpty().WithMessage("Error")
                                            .NotNull().WithMessage("Error");
        }
    }
}
