using AI.CodingAssessment.Application.DTOs.AIFeedback;
using AI.CodingAssessment.Application.DTOs.CodeExecution;
using AI.CodingAssessment.Application.Interfaces;
using AI.CodingAssessment.Domain.Enums;

namespace AI.CodingAssessment.Infrastructure.AI;

public class ExternalAIFeedbackService : IAIFeedbackService
{
    public Task<AIFeedbackDto> AnalyzeSubmissionAsync(
        Guid submissionId,
        string problemDescription,
        string sourceCode,
        ProgrammingLanguage language,
        ExecutionResultDto executionResult,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("ExternalAIFeedbackService.AnalyzeSubmissionAsync is an architectural stub. Configure AI Provider settings in appsettings.json.");
    }

    public Task<AIFeedbackDto> GenerateFeedbackAsync(
        string sourceCode,
        ProgrammingLanguage language,
        string problemContext,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("ExternalAIFeedbackService.GenerateFeedbackAsync is an architectural stub. Configure AI Provider settings in appsettings.json.");
    }
}
