namespace EGHeals.Application.Dtos.Users;

public record CreateSubUserDto(string Username, string Password, Guid AdminId, IEnumerable<CreateUserRoleDto> UserRoles);
