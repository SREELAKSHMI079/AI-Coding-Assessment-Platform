using AI.CodingAssessment.Application.DTOs.Problems;
using AI.CodingAssessment.Application.Interfaces;
using AI.CodingAssessment.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AI.CodingAssessment.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProblemsController : ControllerBase
{
    private readonly IProblemService _problemService;

    public ProblemsController(IProblemService problemService)
    {
        _problemService = problemService;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProblemDto>))]
    public async Task<IActionResult> GetProblems([FromQuery] DifficultyLevel? difficulty, [FromQuery] string? tag, CancellationToken cancellationToken)
    {
        var filter = new ProblemFilterDto(difficulty, tag);
        var problems = await _problemService.GetProblemsAsync(filter, cancellationToken);
        return Ok(problems);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProblemDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProblemById(Guid id, CancellationToken cancellationToken)
    {
        var problem = await _problemService.GetProblemByIdAsync(id, cancellationToken);
        if (problem == null)
            return NotFound();

        return Ok(problem);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProblemDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateProblem([FromBody] CreateProblemDto dto, CancellationToken cancellationToken)
    {
        var problem = await _problemService.CreateProblemAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetProblemById), new { id = problem.Id }, problem);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProblemDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProblem(Guid id, [FromBody] UpdateProblemDto dto, CancellationToken cancellationToken)
    {
        var problem = await _problemService.UpdateProblemAsync(id, dto, cancellationToken);
        return Ok(problem);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProblem(Guid id, CancellationToken cancellationToken)
    {
        await _problemService.DeleteProblemAsync(id, cancellationToken);
        return NoContent();
    }
}
