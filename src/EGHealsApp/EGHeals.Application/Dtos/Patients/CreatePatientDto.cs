using EGHeals.Domain.Enums;

namespace EGHeals.Application.Dtos.Patients;

public record CreatePatientDto(string FullName, string? NationalId, string? Mobile, DateTime DateOfBirth, Gender Gender, Guid? GuardianId);
