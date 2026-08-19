using AI.CodingAssessment.Domain.Enums;

namespace AI.CodingAssessment.Application.DTOs.Problems;

public record ProblemDto(
    Guid Id,
    string Title,
    string Description,
    DifficultyLevel Difficulty,
    string Tags,
    string InputFormat,
    string OutputFormat,
    string Constraints,
    string SampleTestCases,
    DateTime CreatedAt,
    bool IsActive
);

public record CreateProblemDto(
    string Title,
    string Description,
    DifficultyLevel Difficulty,
    string Tags,
    string InputFormat,
    string OutputFormat,
    string Constraints,
    string SampleTestCases,
    bool IsActive = true
);

public record UpdateProblemDto(
    string Title,
    string Description,
    DifficultyLevel Difficulty,
    string Tags,
    string InputFormat,
    string OutputFormat,
    string Constraints,
    string SampleTestCases,
    bool IsActive
);

public record ProblemFilterDto(
    DifficultyLevel? Difficulty,
    string? Tag,
    bool? IsActive = true
);
