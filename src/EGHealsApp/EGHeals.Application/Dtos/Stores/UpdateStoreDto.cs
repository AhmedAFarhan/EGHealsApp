namespace EGHeals.Application.Dtos.Stores;
public record UpdateStoreDto(string Name, Guid BranchId, string? Description);