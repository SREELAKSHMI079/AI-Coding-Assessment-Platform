using AI.CodingAssessment.Domain.Entities;

namespace AI.CodingAssessment.Domain.Interfaces;

public interface ISubmissionRepository : IRepository<Submission>
{
    Task<IReadOnlyList<Submission>> GetUserSubmissionsAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Submission?> GetWithFeedbackAsync(Guid submissionId, CancellationToken cancellationToken = default);
}
