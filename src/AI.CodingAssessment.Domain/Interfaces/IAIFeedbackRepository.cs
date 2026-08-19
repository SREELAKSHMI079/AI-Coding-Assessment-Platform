using AI.CodingAssessment.Domain.Entities;

namespace AI.CodingAssessment.Domain.Interfaces;

public interface IAIFeedbackRepository : IRepository<AIFeedback>
{
    Task<AIFeedback?> GetBySubmissionIdAsync(Guid submissionId, CancellationToken cancellationToken = default);
}
