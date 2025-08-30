namespace EGHeals.Application.Dtos.Stores;
public record CreateStoreDto(string Name, Guid BranchId, string? Description);