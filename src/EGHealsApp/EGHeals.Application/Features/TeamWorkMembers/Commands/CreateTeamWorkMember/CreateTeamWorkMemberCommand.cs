using EGHeals.Application.Dtos.TeamWorkMemberAllowances;
using EGHeals.Application.Dtos.TeamWorkMemberBranches;
using EGHeals.Application.Dtos.TeamWorkMembers;
using EGHeals.Domain.Enums;

namespace EGHeals.Application.Features.TeamWorkMembers.Commands.CreateTeamWorkMember
{
    public record CreateTeamWorkMemberCommand(CreateTeamWorkMemberDto TeamworkMember) : ICommand<CreateTeamWorkMemberResult>;
    public record CreateTeamWorkMemberResult(Guid Id);

    public class CreateTeamWorkMemberCommandValidator : AbstractValidator<CreateTeamWorkMemberCommand>
    {
        public CreateTeamWorkMemberCommandValidator()
        {
            RuleFor(x => x.TeamworkMember).NotNull().WithMessage("Error")
                                          .SetValidator(new CreateTeamWorkMemberDtoValidator());
        }
    }

    public class CreateTeamWorkMemberDtoValidator : AbstractValidator<CreateTeamWorkMemberDto>
    {
        public CreateTeamWorkMemberDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Error")
                                    .NotNullOrWhitespace("Error")
                                    .MaximumLength(150).WithMessage("Error")
                                    .MinimumLength(3).WithMessage("Error");

            RuleFor(x => x.NationalId).NotEmpty().WithMessage("Error")
                                      .Length(11).WithMessage("Error")
                                      .When(x => !string.IsNullOrEmpty(x.NationalId));

            RuleFor(x => x.Mobile).EgyptianMobile();

            RuleFor(x => x.StuffTitle).NotNull().WithMessage("Error")
                                      .Must(value => Enum.IsDefined(typeof(StuffTitle), value)).WithMessage("Error");

            RuleFor(x => x.StuffSalaryType).NotNull().WithMessage("Error")
                                           .Must(value => Enum.IsDefined(typeof(StuffSalaryType), value)).WithMessage("Error");

            RuleFor(x => x.Salary).NotEmpty().WithMessage("Error")
                                  .LessThan(0).WithMessage("Error");

            RuleFor(x => x.UserMemberId).NotEmpty().WithMessage("Error");

            RuleForEach(x => x.TeamWorkMemberAllowances).SetValidator(new TeamWorkMemberAllowanceDtoValidator());

            RuleForEach(x => x.TeamWorkMemberBranches).SetValidator(new TeamWorkMemberBranchDtoValidator());
        }
    }

    public class TeamWorkMemberAllowanceDtoValidator : AbstractValidator<TeamWorkMemberAllowanceDto>
    {
        public TeamWorkMemberAllowanceDtoValidator()
        {
            RuleFor(x => x.TeamWorkMemberId).NotEmpty().WithMessage("Error")
                                  .NotNull().WithMessage("Error");

            RuleFor(x => x.AllowanceId).NotEmpty().WithMessage("Error")
                                  .NotNull().WithMessage("Error");

            RuleFor(x => x.Cost).NotEmpty().WithMessage("Error")
                                 .LessThan(0).WithMessage("Error");
        }
    }

    public class TeamWorkMemberBranchDtoValidator : AbstractValidator<TeamWorkMemberBranchDto>
    {
        public TeamWorkMemberBranchDtoValidator()
        {
            RuleFor(x => x.TeamWorkMemberId).NotEmpty().WithMessage("Error")
                                  .NotNull().WithMessage("Error");

            RuleFor(x => x.BranchId).NotEmpty().WithMessage("Error")
                                  .NotNull().WithMessage("Error");
        }
    }

}
