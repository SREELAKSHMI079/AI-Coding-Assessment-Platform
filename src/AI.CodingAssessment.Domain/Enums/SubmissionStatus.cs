namespace AI.CodingAssessment.Domain.Enums;

public enum SubmissionStatus
{
    Pending = 1,
    Compiling = 2,
    Running = 3,
    Accepted = 4,
    WrongAnswer = 5,
    TimeLimitExceeded = 6,
    MemoryLimitExceeded = 7,
    RuntimeError = 8,
    CompilationError = 9
}
