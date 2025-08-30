using EGHeals.Application.Dtos.TechnicianDevices;
using EGHeals.Application.Dtos.TechnicianExaminationCosts;

namespace EGHeals.Application.Dtos.Technicians;

public record CreateTechnicianDto(string Name, Guid TeamWorkMemberId, IEnumerable<TechnicianDeviceDto> TechnicianDevices, IEnumerable<TechnicianExaminationCostDto> TechnicianExaminationCosts);
