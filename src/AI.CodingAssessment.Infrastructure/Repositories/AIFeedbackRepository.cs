using AI.CodingAssessment.Domain.Entities;
using AI.CodingAssessment.Domain.Interfaces;
using AI.CodingAssessment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AI.CodingAssessment.Infrastructure.Repositories;

public class AIFeedbackRepository : Repository<AIFeedback>, IAIFeedbackRepository
{
    public AIFeedbackRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<AIFeedback?> GetBySubmissionIdAsync(Guid submissionId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.AIFeedbacks
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.SubmissionId == submissionId, cancellationToken);
    }
}
