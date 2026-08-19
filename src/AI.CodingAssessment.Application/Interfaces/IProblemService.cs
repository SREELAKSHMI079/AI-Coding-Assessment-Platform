using AI.CodingAssessment.Application.DTOs.Problems;

namespace AI.CodingAssessment.Application.Interfaces;

public interface IProblemService
{
    Task<IReadOnlyList<ProblemDto>> GetProblemsAsync(ProblemFilterDto filter, CancellationToken cancellationToken = default);
    Task<ProblemDto?> GetProblemByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<ProblemDto> CreateProblemAsync(CreateProblemDto dto, CancellationToken cancellationToken = default);
    Task<ProblemDto> UpdateProblemAsync(Guid id, UpdateProblemDto dto, CancellationToken cancellationToken = default);
    Task DeleteProblemAsync(Guid id, CancellationToken cancellationToken = default);
}
