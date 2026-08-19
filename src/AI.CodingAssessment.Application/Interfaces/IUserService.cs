using AI.CodingAssessment.Application.DTOs.Users;

namespace AI.CodingAssessment.Application.Interfaces;

public interface IUserService
{
    Task<UserDto?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UserProfileDto?> GetUserProfileAsync(Guid id, CancellationToken cancellationToken = default);
}
