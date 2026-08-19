namespace AI.CodingAssessment.Domain.Entities;

public class AIFeedback
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SubmissionId { get; set; }
    public Submission? Submission { get; set; }

    public string CorrectnessAnalysis { get; set; } = string.Empty;
    public string EfficiencyAnalysis { get; set; } = string.Empty;
    public string ReadabilityAnalysis { get; set; } = string.Empty;
    public string Suggestions { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
