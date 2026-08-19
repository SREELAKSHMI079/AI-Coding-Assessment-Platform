using AI.CodingAssessment.Application.DTOs.CodeExecution;
using AI.CodingAssessment.Application.Interfaces;
using AI.CodingAssessment.Domain.Enums;

namespace AI.CodingAssessment.Infrastructure.CodeExecution.Runners;

public class PythonExecutionService : ICodeLanguageRunner
{
    public ProgrammingLanguage SupportedLanguage => ProgrammingLanguage.Python;

    public Task<ExecutionResultDto> ExecuteAsync(ExecutionRequestDto request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("PythonExecutionService.ExecuteAsync is an architectural stub. Python sandbox execution runner will be implemented in future phase.");
    }
}
