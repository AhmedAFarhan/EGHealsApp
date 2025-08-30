﻿using EGHeals.Application.Dtos.RadiologistDevices;
using EGHeals.Application.Dtos.RadiologistExaminationsCosts;

namespace EGHeals.Application.Dtos.Radiologists;
public record UpdateRadiologistDto(IEnumerable<RadiologistDeviceDto> RadiologistDevices, IEnumerable<RadiologistExaminationCostDto> RadiologistExaminationCosts);