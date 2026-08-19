namespace AI.CodingAssessment.Application.DTOs.TestCases;

public record TestCaseDto(
    Guid Id,
    Guid ProblemId,
    string Input,
    string ExpectedOutput,
    bool IsHidden,
    int MemoryLimitMb,
    int TimeLimitMs
);

public record CreateTestCaseDto(
    Guid ProblemId,
    string Input,
    string ExpectedOutput,
    bool IsHidden,
    int MemoryLimitMb,
    int TimeLimitMs
);

public record UpdateTestCaseDto(
    string Input,
    string ExpectedOutput,
    bool IsHidden,
    int MemoryLimitMb,
    int TimeLimitMs
);
