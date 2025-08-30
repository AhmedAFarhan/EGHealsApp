namespace EGHeals.Application.Dtos.Branches;

public record CreateBranchDto(string Name, double Latitude, double Longitude, string? HowToReach);