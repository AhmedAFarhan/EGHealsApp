using EGHeals.Application.Dtos.TeamWorkMemberAllowances;
using EGHeals.Application.Dtos.TeamWorkMemberBranches;
using EGHeals.Domain.Enums;

namespace EGHeals.Application.Dtos.TeamWorkMembers;

public record CreateTeamWorkMemberDto(string FullName,
                                     string? NationalId,
                                     string Mobile, 
                                     StuffTitle StuffTitle, 
                                     StuffSalaryType StuffSalaryType,
                                     decimal Salary,
                                     Guid? UserMemberId,
                                     IEnumerable<TeamWorkMemberAllowanceDto> TeamWorkMemberAllowances,
                                     IEnumerable<TeamWorkMemberBranchDto> TeamWorkMemberBranches);
