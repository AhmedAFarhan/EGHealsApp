using EGHeals.Domain.Enums;

namespace EGHeals.Application.Dtos.TechnicianDevices;

public record TechnicianDeviceDto(Guid TechnicianId, RadiologyDevice RadiologyDevice);