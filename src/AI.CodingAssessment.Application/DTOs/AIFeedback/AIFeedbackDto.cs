namespace AI.CodingAssessment.Application.DTOs.AIFeedback;

public record AIFeedbackDto(
    Guid Id,
    Guid SubmissionId,
    string CorrectnessAnalysis,
    string EfficiencyAnalysis,
    string ReadabilityAnalysis,
    string Suggestions,
    DateTime CreatedAt
);
