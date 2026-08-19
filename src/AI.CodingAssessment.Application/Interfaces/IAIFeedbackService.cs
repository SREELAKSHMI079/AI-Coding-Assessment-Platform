using AI.CodingAssessment.Application.DTOs.AIFeedback;
using AI.CodingAssessment.Application.DTOs.CodeExecution;
using AI.CodingAssessment.Domain.Enums;

namespace AI.CodingAssessment.Application.Interfaces;

public interface IAIFeedbackService
{
    Task<AIFeedbackDto> AnalyzeSubmissionAsync(Guid submissionId, string problemDescription, string sourceCode, ProgrammingLanguage language, ExecutionResultDto executionResult, CancellationToken cancellationToken = default);
    Task<AIFeedbackDto> GenerateFeedbackAsync(string sourceCode, ProgrammingLanguage language, string problemContext, CancellationToken cancellationToken = default);
}
