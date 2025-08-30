using EGHeals.Domain.Enums;

namespace EGHeals.Application.Dtos.Patients;
public record UpdatePatientDto(string FullName, string? NationalId, string? Mobile, DateTime DateOfBirth, Gender Gender);