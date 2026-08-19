using AI.CodingAssessment.Application.DTOs.TestCases;

namespace AI.CodingAssessment.Application.Interfaces;

public interface ITestCaseService
{
    Task<IReadOnlyList<TestCaseDto>> GetTestCasesByProblemIdAsync(Guid problemId, CancellationToken cancellationToken = default);
    Task<TestCaseDto> CreateTestCaseAsync(Guid problemId, CreateTestCaseDto dto, CancellationToken cancellationToken = default);
    Task<TestCaseDto> UpdateTestCaseAsync(Guid id, UpdateTestCaseDto dto, CancellationToken cancellationToken = default);
    Task DeleteTestCaseAsync(Guid id, CancellationToken cancellationToken = default);
}
