namespace AI.CodingAssessment.Domain.Entities;

public class TestCase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProblemId { get; set; }
    public Problem? Problem { get; set; }

    public string Input { get; set; } = string.Empty;
    public string ExpectedOutput { get; set; } = string.Empty;
    public bool IsHidden { get; set; } = true;
    public int MemoryLimitMb { get; set; } = 256;
    public int TimeLimitMs { get; set; } = 2000;
}
