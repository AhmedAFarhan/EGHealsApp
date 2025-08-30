using Microsoft.AspNetCore.Identity;

namespace EGHeals.Application.Features.Users.Commands.CreateUser
{
    public class CreateSubUserHandler(IUnitOfWork unitOfWork, IPasswordHasher<object> passwordHasher) : ICommandHandler<CreateSubUserCommand, CreateSubUserResult>
    {
        public async Task<CreateSubUserResult> Handle(CreateSubUserCommand request, CancellationToken cancellationToken)
        {

            return new CreateSubUserResult(Guid.NewGuid());
        }
    }
}
