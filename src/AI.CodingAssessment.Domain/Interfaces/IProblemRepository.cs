using AI.CodingAssessment.Domain.Entities;
using AI.CodingAssessment.Domain.Enums;

namespace AI.CodingAssessment.Domain.Interfaces;

public interface IProblemRepository : IRepository<Problem>
{
    Task<IReadOnlyList<Problem>> GetFilteredAsync(DifficultyLevel? difficulty, string? tag, CancellationToken cancellationToken = default);
    Task<Problem?> GetWithTestCasesAsync(Guid problemId, CancellationToken cancellationToken = default);
}
