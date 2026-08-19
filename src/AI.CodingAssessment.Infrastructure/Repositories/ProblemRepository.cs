using AI.CodingAssessment.Domain.Entities;
using AI.CodingAssessment.Domain.Enums;
using AI.CodingAssessment.Domain.Interfaces;
using AI.CodingAssessment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AI.CodingAssessment.Infrastructure.Repositories;

public class ProblemRepository : Repository<Problem>, IProblemRepository
{
    public ProblemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Problem>> GetFilteredAsync(DifficultyLevel? difficulty, string? tag, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Problems.AsNoTracking().Where(p => p.IsActive);

        if (difficulty.HasValue)
        {
            query = query.Where(p => p.Difficulty == difficulty.Value);
        }

        if (!string.IsNullOrWhiteSpace(tag))
        {
            query = query.Where(p => p.Tags.Contains(tag));
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<Problem?> GetWithTestCasesAsync(Guid problemId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Problems
            .Include(p => p.TestCases)
            .FirstOrDefaultAsync(p => p.Id == problemId, cancellationToken);
    }
}
