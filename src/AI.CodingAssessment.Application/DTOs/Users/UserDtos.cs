using AI.CodingAssessment.Domain.Enums;

namespace AI.CodingAssessment.Application.DTOs.Users;

public record UserDto(
    Guid Id,
    string Username,
    string Email,
    UserRole Role,
    DateTime CreatedAt
);

public record UserProfileDto(
    Guid Id,
    string Username,
    string Email,
    UserRole Role,
    int TotalSubmissions,
    int AcceptedSubmissions,
    DateTime CreatedAt
);
