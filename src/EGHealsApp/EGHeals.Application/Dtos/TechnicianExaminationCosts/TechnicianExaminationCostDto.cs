namespace EGHeals.Application.Dtos.TechnicianExaminationCosts;

public record TechnicianExaminationCostDto(Guid TechnicianId, Guid ExaminationId, decimal Cost);