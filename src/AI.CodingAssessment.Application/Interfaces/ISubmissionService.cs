using AI.CodingAssessment.Application.DTOs.Submissions;

namespace AI.CodingAssessment.Application.Interfaces;

public interface ISubmissionService
{
    Task<SubmissionDto> CreateSubmissionAsync(CreateSubmissionDto dto, CancellationToken cancellationToken = default);
    Task<SubmissionDto> SubmitSolutionAsync(CreateSubmissionDto dto, CancellationToken cancellationToken = default);
    Task<SubmissionDto?> GetSubmissionByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<SubmissionHistoryDto>> GetUserSubmissionHistoryAsync(Guid userId, CancellationToken cancellationToken = default);
}
