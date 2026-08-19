using AI.CodingAssessment.Application.DTOs.CodeExecution;
using AI.CodingAssessment.Domain.Enums;

namespace AI.CodingAssessment.Application.Interfaces;

public interface ICodeExecutionService
{
    Task<ExecutionResultDto> ExecuteCodeAsync(ExecutionRequestDto request, CancellationToken cancellationToken = default);
    Task<ExecutionResultDto> RunTestCasesAsync(string sourceCode, ProgrammingLanguage language, IEnumerable<TestCaseInputDto> testCases, CancellationToken cancellationToken = default);
}
