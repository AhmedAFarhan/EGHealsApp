namespace EGHeals.Application.Dtos.RadiologistExaminationsCosts;
public record RadiologistExaminationCostDto(Guid RadiologistId, Guid ExaminationId, decimal Cost);