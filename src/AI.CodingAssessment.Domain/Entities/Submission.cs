using AI.CodingAssessment.Domain.Enums;

namespace AI.CodingAssessment.Domain.Entities;

public class Submission
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid ProblemId { get; set; }
    public Problem? Problem { get; set; }

    public string SourceCode { get; set; } = string.Empty;
    public ProgrammingLanguage Language { get; set; } = ProgrammingLanguage.Python;
    public SubmissionStatus Status { get; set; } = SubmissionStatus.Pending;
    public int ExecutionTimeMs { get; set; }
    public int MemoryUsedKb { get; set; }
    public int TestCasesPassed { get; set; }
    public int TotalTestCases { get; set; }
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

    public AIFeedback? AIFeedback { get; set; }
}
