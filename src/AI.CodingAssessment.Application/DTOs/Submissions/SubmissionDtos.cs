using AI.CodingAssessment.Application.DTOs.AIFeedback;
using AI.CodingAssessment.Domain.Enums;

namespace AI.CodingAssessment.Application.DTOs.Submissions;

public record SubmissionDto(
    Guid Id,
    Guid UserId,
    Guid ProblemId,
    string SourceCode,
    ProgrammingLanguage Language,
    SubmissionStatus Status,
    int ExecutionTimeMs,
    int MemoryUsedKb,
    int TestCasesPassed,
    int TotalTestCases,
    DateTime SubmittedAt,
    AIFeedbackDto? AIFeedback
);

public record CreateSubmissionDto(
    Guid UserId,
    Guid ProblemId,
    string SourceCode,
    ProgrammingLanguage Language
);

public record SubmissionHistoryDto(
    Guid Id,
    Guid ProblemId,
    string ProblemTitle,
    ProgrammingLanguage Language,
    SubmissionStatus Status,
    int ExecutionTimeMs,
    int MemoryUsedKb,
    int TestCasesPassed,
    int TotalTestCases,
    DateTime SubmittedAt
);
