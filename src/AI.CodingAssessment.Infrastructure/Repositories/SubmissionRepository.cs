using AI.CodingAssessment.Domain.Entities;
using AI.CodingAssessment.Domain.Interfaces;
using AI.CodingAssessment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AI.CodingAssessment.Infrastructure.Repositories;

public class SubmissionRepository : Repository<Submission>, ISubmissionRepository
{
    public SubmissionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Submission>> GetUserSubmissionsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Submissions
            .AsNoTracking()
            .Include(s => s.Problem)
            .Where(s => s.UserId == userId)
            .OrderByDescending(s => s.SubmittedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Submission?> GetWithFeedbackAsync(Guid submissionId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Submissions
            .Include(s => s.AIFeedback)
            .Include(s => s.Problem)
            .FirstOrDefaultAsync(s => s.Id == submissionId, cancellationToken);
    }
}
