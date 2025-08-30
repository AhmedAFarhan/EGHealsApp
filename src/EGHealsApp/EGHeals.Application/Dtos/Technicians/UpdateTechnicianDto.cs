using EGHeals.Application.Dtos.TechnicianDevices;
using EGHeals.Application.Dtos.TechnicianExaminationCosts;

namespace EGHeals.Application.Dtos.Technicians;

public record UpdateTechnicianDto(IEnumerable<TechnicianDeviceDto> TechnicianDevices, IEnumerable<TechnicianExaminationCostDto> TechnicianExaminationCosts);
