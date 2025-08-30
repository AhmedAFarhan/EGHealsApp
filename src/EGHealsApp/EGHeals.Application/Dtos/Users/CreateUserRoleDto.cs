namespace EGHeals.Application.Dtos.Users
{
    public record CreateUserRoleDto(Guid UserId, Guid RoleId, IEnumerable<CreateUserRolePermissionDto> UserRolePermissions);
}
