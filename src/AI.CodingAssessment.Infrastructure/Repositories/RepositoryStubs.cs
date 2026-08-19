using System.Linq.Expressions;
using AI.CodingAssessment.Domain.Entities;
using AI.CodingAssessment.Domain.Enums;
using AI.CodingAssessment.Domain.Interfaces;
using AI.CodingAssessment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AI.CodingAssessment.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _dbContext;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
    }
}

public class ProblemRepository : Repository<Problem>, IProblemRepository
{
    public ProblemRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public async Task<IReadOnlyList<Problem>> GetFilteredAsync(DifficultyLevel? difficulty, string? tag, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Problems.AsQueryable();
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
        return await _dbContext.Problems.Include(p => p.TestCases).FirstOrDefaultAsync(p => p.Id == problemId, cancellationToken);
    }
}

public class TestCaseRepository : Repository<TestCase>, ITestCaseRepository
{
    public TestCaseRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public async Task<IReadOnlyList<TestCase>> GetByProblemIdAsync(Guid problemId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.TestCases.Where(tc => tc.ProblemId == problemId).ToListAsync(cancellationToken);
    }
}

public class SubmissionRepository : Repository<Submission>, ISubmissionRepository
{
    public SubmissionRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public async Task<IReadOnlyList<Submission>> GetUserSubmissionsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Submissions
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

public class AIFeedbackRepository : Repository<AIFeedback>, IAIFeedbackRepository
{
    public AIFeedbackRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public async Task<AIFeedback?> GetBySubmissionIdAsync(Guid submissionId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.AIFeedbacks.FirstOrDefaultAsync(f => f.SubmissionId == submissionId, cancellationToken);
    }
}
