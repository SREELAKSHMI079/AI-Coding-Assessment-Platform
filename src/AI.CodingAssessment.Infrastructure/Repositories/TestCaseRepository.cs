using AI.CodingAssessment.Domain.Entities;
using AI.CodingAssessment.Domain.Interfaces;
using AI.CodingAssessment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AI.CodingAssessment.Infrastructure.Repositories;

public class TestCaseRepository : Repository<TestCase>, ITestCaseRepository
{
    public TestCaseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<TestCase>> GetByProblemIdAsync(Guid problemId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.TestCases
            .AsNoTracking()
            .Where(tc => tc.ProblemId == problemId)
            .ToListAsync(cancellationToken);
    }
}
