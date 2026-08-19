using AI.CodingAssessment.Application.DTOs.CodeExecution;
using AI.CodingAssessment.Application.Interfaces;
using AI.CodingAssessment.Domain.Enums;

namespace AI.CodingAssessment.Infrastructure.CodeExecution.Runners;

public class JavaExecutionService : ICodeLanguageRunner
{
    public ProgrammingLanguage SupportedLanguage => ProgrammingLanguage.Java;

    public Task<ExecutionResultDto> ExecuteAsync(ExecutionRequestDto request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("JavaExecutionService.ExecuteAsync is an architectural stub. Java compilation & sandbox execution runner will be implemented in future phase.");
    }
}
