using AI.CodingAssessment.Application.DTOs.Submissions;
using AI.CodingAssessment.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AI.CodingAssessment.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SubmissionsController : ControllerBase
{
    private readonly ISubmissionService _submissionService;

    public SubmissionsController(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SubmissionDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateSubmission([FromBody] CreateSubmissionDto dto, CancellationToken cancellationToken)
    {
        // Executes workflow: SubmissionsController -> SubmissionService -> CodeExecutionService -> AIFeedbackService -> DB
        var submission = await _submissionService.SubmitSolutionAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetSubmissionById), new { id = submission.Id }, submission);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubmissionDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSubmissionById(Guid id, CancellationToken cancellationToken)
    {
        var submission = await _submissionService.GetSubmissionByIdAsync(id, cancellationToken);
        if (submission == null)
            return NotFound();

        return Ok(submission);
    }

    [HttpGet("history")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SubmissionHistoryDto>))]
    public async Task<IActionResult> GetUserSubmissionHistory([FromQuery] Guid userId, CancellationToken cancellationToken)
    {
        var history = await _submissionService.GetUserSubmissionHistoryAsync(userId, cancellationToken);
        return Ok(history);
    }
}
