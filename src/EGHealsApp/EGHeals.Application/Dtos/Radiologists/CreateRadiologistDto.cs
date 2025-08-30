using EGHeals.Application.Dtos.RadiologistDevices;
using EGHeals.Application.Dtos.RadiologistExaminationsCosts;

namespace EGHeals.Application.Dtos.Radiologists;
public record CreateRadiologistDto(string Name, Guid TeamWorkMemberId, IEnumerable<RadiologistDeviceDto> RadiologistDevices, IEnumerable<RadiologistExaminationCostDto> RadiologistExaminationCosts);