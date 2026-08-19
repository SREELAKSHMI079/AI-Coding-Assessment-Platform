using AI.CodingAssessment.Application.DTOs.CodeExecution;
using AI.CodingAssessment.Domain.Enums;

namespace AI.CodingAssessment.Application.Interfaces;

public interface ICodeLanguageRunner
{
    ProgrammingLanguage SupportedLanguage { get; }
    Task<ExecutionResultDto> ExecuteAsync(ExecutionRequestDto request, CancellationToken cancellationToken = default);
}
