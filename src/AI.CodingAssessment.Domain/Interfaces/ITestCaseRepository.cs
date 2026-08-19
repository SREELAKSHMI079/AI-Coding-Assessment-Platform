using AI.CodingAssessment.Domain.Entities;

namespace AI.CodingAssessment.Domain.Interfaces;

public interface ITestCaseRepository : IRepository<TestCase>
{
    Task<IReadOnlyList<TestCase>> GetByProblemIdAsync(Guid problemId, CancellationToken cancellationToken = default);
}
