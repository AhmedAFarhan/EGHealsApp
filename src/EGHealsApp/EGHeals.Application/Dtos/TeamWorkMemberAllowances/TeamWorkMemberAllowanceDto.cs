namespace EGHeals.Application.Dtos.TeamWorkMemberAllowances;

public record TeamWorkMemberAllowanceDto(Guid TeamWorkMemberId, Guid AllowanceId, decimal Cost);
