using AI.CodingAssessment.Domain.Enums;

namespace AI.CodingAssessment.Application.DTOs.CodeExecution;

public record ExecutionRequestDto(
    string SourceCode,
    ProgrammingLanguage Language,
    Guid ProblemId,
    IReadOnlyList<TestCaseInputDto> TestCases
);

public record TestCaseInputDto(
    Guid Id,
    string Input,
    string ExpectedOutput,
    int TimeLimitMs,
    int MemoryLimitMb
);

public record TestCaseResultDto(
    Guid TestCaseId,
    bool Passed,
    string ActualOutput,
    string ExpectedOutput,
    int ExecutionTimeMs,
    int MemoryUsedKb,
    string ErrorMessage
);

public record ExecutionResultDto(
    SubmissionStatus Status,
    int TotalExecutionTimeMs,
    int PeakMemoryUsedKb,
    int TestCasesPassed,
    int TotalTestCases,
    string CompilerOutput,
    string ErrorMessage,
    IReadOnlyList<TestCaseResultDto> TestCaseResults
);
