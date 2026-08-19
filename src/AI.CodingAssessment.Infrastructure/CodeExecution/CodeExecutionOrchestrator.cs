using AI.CodingAssessment.Application.DTOs.CodeExecution;
using AI.CodingAssessment.Application.Exceptions;
using AI.CodingAssessment.Application.Interfaces;
using AI.CodingAssessment.Domain.Enums;

namespace AI.CodingAssessment.Infrastructure.CodeExecution;

public class CodeExecutionOrchestrator : ICodeExecutionService
{
    private readonly IEnumerable<ICodeLanguageRunner> _runners;

    public CodeExecutionOrchestrator(IEnumerable<ICodeLanguageRunner> runners)
    {
        _runners = runners;
    }

    public async Task<ExecutionResultDto> ExecuteCodeAsync(ExecutionRequestDto request, CancellationToken cancellationToken = default)
    {
        var runner = _runners.FirstOrDefault(r => r.SupportedLanguage == request.Language);
        if (runner == null)
        {
            throw new CodeExecutionException($"No code execution runner found for programming language: {request.Language}");
        }

        return await runner.ExecuteAsync(request, cancellationToken);
    }

    public async Task<ExecutionResultDto> RunTestCasesAsync(string sourceCode, ProgrammingLanguage language, IEnumerable<TestCaseInputDto> testCases, CancellationToken cancellationToken = default)
    {
        var request = new ExecutionRequestDto(
            SourceCode: sourceCode,
            Language: language,
            ProblemId: Guid.Empty,
            TestCases: testCases.ToList()
        );

        return await ExecuteCodeAsync(request, cancellationToken);
    }
}
