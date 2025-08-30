namespace EGHeals.Application.Dtos.Allowances;

public record CreateAllowanceDto(string Name, decimal Cost, string? Description);