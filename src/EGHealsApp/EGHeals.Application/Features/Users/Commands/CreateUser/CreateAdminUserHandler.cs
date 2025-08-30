using Microsoft.AspNetCore.Identity;

namespace EGHeals.Application.Features.Users.Commands.CreateUser
{
    public class CreateAdminUserHandler(IUnitOfWork unitOfWork, IPasswordHasher<object> passwordHasher) : ICommandHandler<CreateAdminUserCommand, CreateAdminUserResult>
    {
        public async Task<CreateAdminUserResult> Handle(CreateAdminUserCommand request, CancellationToken cancellationToken)
        {

            return new CreateAdminUserResult(Guid.NewGuid());
        }
    }
}
